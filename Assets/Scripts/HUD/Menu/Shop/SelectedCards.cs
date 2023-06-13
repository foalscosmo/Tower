using System;
using System.Collections.Generic;
using TMPro;
using Tower;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Menu.Shop
{
    /// <summary>
    /// Manages the selection of cards in the shop menu.
    /// </summary>
    public class SelectedCards : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> buttonText = new(); // List of UI text elements for button labels
        [SerializeField] public List<Card> selected = new(); // List of selected cards
        [SerializeField] private List<Button> selectedCardsButtons = new(); // List of buttons associated with selected cards
        [SerializeField] public List<int> cardIndex = new();  // List of card indices
        [SerializeField] private List<int> receivedCardId = new();  // List of received card IDs
        [SerializeField] private ShopCardButtonContainer shopCardButtonContainer; // Reference to the shop card button container
        [SerializeField] private ShopCards shopCards;  // Reference to the shop cards
        [SerializeField] private CardsListForGame cardsListForGame;  // Reference to the cards list for the game
        public event Action<int> OnRemovePressed;  // Event triggered when a card is removed
        public event Action<int> OnListCheck; // Event triggered when the selected cards list is checked
        
        public int Number { get; private set; }  // Number property for tracking the selected card index

        /// <summary>
        /// Initializes the card index list and clears the cards list for the game.
        /// </summary>
        private void Awake()
        {
            for (var i = 0; i < cardIndex.Count; i++) cardIndex[i] = 9; // Initialize the card index list with default value 9
            for (var i = 0; i < selected.Count; i++) cardsListForGame.Cards[i] = null; // Clear the cards list for the game
        }
        
        /// <summary>
        /// Subscribes to the shop card button pressed event when the object becomes enabled.
        /// </summary>
        private void OnEnable()
        {
            foreach (var t in shopCardButtonContainer.ShopCardInteracts) 
                t.OnShopCardPressed += SelectCard;  // Subscribe to the shop card button pressed event
        }
        
        /// <summary>
        /// Unsubscribes from the shop card button pressed event when the object becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            foreach (var t in shopCardButtonContainer.ShopCardInteracts)
                t.OnShopCardPressed -= SelectCard;  // Unsubscribe from the shop card button pressed event
        }
        
        /// <summary>
        /// Updates the selected cards UI and checks the selected cards list for changes.
        /// </summary>
        private void LateUpdate()
        {
            for (var index = 0; index < cardIndex.Count; index++)
            {
                OnListCheck?.Invoke(selected[index] is not null ? 1 : 0); // Invoke the OnListCheck event based on card selection status

                switch (cardIndex[index])
                {
                    case 9:
                        Number = cardIndex.FindIndex(x => x == 9); // Find the next available card index
                        selectedCardsButtons[index].interactable = false; // Disable the button associated with the unselected card
                        break;
                    default:
                        selectedCardsButtons[index].interactable = true; // Enable the button associated with the selected card
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the selected cards in the cards list for the game.
        /// </summary>
        public void SetInGameCards()
        {
            for (var i = 0; i < selected.Count; i++) cardsListForGame.Cards[i] = selected[i]; // Set the selected cards in the cards list for the game
        }
        
        /// <summary>
        /// Selects a card from the shop cards.
        /// </summary>
        private void SelectCard(int index)
        {
            selected[Number] = shopCards.CardContainer[index]; // Select a card from the shop cards
            receivedCardId[Number] = index;  // Assign the received card ID
            buttonText[Number].text = selected[Number].name;  // Update the button label with the selected card name
            selectedCardsButtons[Number].image.color = selected[Number].material.color; // Update the button color with the selected card material color
            Number++; // Increment the

            Number = cardIndex.FindIndex(x => x == 9);  // Find the index in the cardIndex list where the value is 9 and assign it to Number

            cardIndex[Number] = Number;  // Set the value at the found index in the cardIndex list to the value of Number
        }
        
        /// <summary>
        /// Removes a card from the selected cards.
        /// </summary>
        public void RemoveCard(int index)
        {
            selected[index] = null;  // Clear the selected card at the specified index
            cardIndex[index] = 9; // Reset the card index to the default value 9
            selectedCardsButtons[index].image.color = Color.white; // Reset the button color to white
            buttonText[index].text = "Card"; // Reset the button label to the default value "Card"
            Number = index; // Update the selected card index
            OnRemovePressed?.Invoke(receivedCardId[index]); // Trigger the OnRemovePressed event and pass the received card ID
            receivedCardId[index] = 0;  // Reset the received card ID to 0
        }
    }
}
