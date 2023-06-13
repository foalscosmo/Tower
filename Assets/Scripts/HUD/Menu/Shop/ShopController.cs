using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HUD.Menu.Shop
{
    /// <summary>
    /// Controls the functionality of the shop in the HUD menu.
    /// </summary>
   
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private List<int> clickCount = new(); // List to track the number of clicks on each shop card
        [SerializeField] private List<int> maxClickCount = new(); // List to store the maximum click count for each shop card
        [SerializeField] private List<int> shopCardId = new(); // List to store the assigned card IDs for each shop card
        [SerializeField] private SelectedCards selectedCards; // Reference to the selected cards component
        [SerializeField] private ShopCardButtonContainer shopCardButtonContainer;  // Reference to the container of shop card buttons

        /// <summary>
        /// Initializes the shop card IDs to a default value.
        /// </summary>
        private void Awake()
        {
            for (var i = 0; i < shopCardId.Count; i++)
            {
                shopCardId[i] = 9; // Initialize the shop card IDs to a default value of 9
            }
        }
        /// <summary>
        /// Subscribes to necessary events when the object becomes enabled.
        /// </summary>
        private void OnEnable()
        {
            selectedCards.OnRemovePressed += CardIdMaker; // Subscribe to the event when a card is removed
            foreach (var t in shopCardButtonContainer.ShopCardInteracts)
            {
                t.OnShopCardPressed += ReturnCardIndex;  // Subscribe to the event when a shop card button is pressed to get the index
            }
        }
        /// <summary>
        /// Unsubscribes from events when the object becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            selectedCards.OnRemovePressed -= CardIdMaker; // Unsubscribe from the event when a card is removed
            foreach (var t in shopCardButtonContainer.ShopCardInteracts)
            {
                t.OnShopCardPressed -= ReturnCardIndex; // Unsubscribe from the event when a shop card button is pressed
            }
        }
        
        /// <summary>
        /// Handles the interaction when a shop card button is pressed.
        /// </summary>
        /// <param name="index">The index of the clicked shop card button.</param>
        public void ShopButtonInteract(int index)
        {
            clickCount[index]++; // Increment the click count for the clicked shop card
            if (clickCount[index] < maxClickCount[index]) return; // If the click count is less than the maximum, return
            shopCardButtonContainer.ShopCardButtons[index].interactable = false; // Disable the intractability of the clicked shop card button
            // Disable the intractability of other shop card buttons if the maximum number of selected cards has been reached
            foreach (var t in shopCardButtonContainer.ShopCardButtons.Where(_ => selectedCards.Number >= 4))
            {
                t.interactable = false;
            }
        }
        /// <summary>
        /// Handles the ID assignment and intractability when a card is removed.
        /// </summary>
        /// <param name="index">The index of the removed card.</param>
        private void CardIdMaker(int index)
        {
            clickCount[index]--; // Decrement the click count when a card is removed
            if (shopCardId[index] != index) return; // If the card ID is not equal to the index, return
            shopCardId[index] = 9; // Reset the card ID to the default value
            
            // Enable the intractability of shop card buttons with default card IDs
            for (var i = 0; i < shopCardId.Count; i++)
            {
                if (shopCardId[i] == 9)
                {
                    shopCardButtonContainer.ShopCardButtons[i].interactable = true;
                }
            }
        }

        private void ReturnCardIndex(int index)
        {
            shopCardId[index] = index; // Assign the index as the card ID
        }
    }
}