
using HUD.Menu;
using TMPro;
using Tower;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.HUDShop
{
    /// <summary>
    /// Manages the HUD shop UI, including button colors and text updates based on card data.
    /// </summary>
    public class HudShop : MonoBehaviour
    { 
        [SerializeField] private CardController cardController;  // Reference to the card controller
        [SerializeField] private CardsListForGame cardsListForGame;  // Reference to the cards list for the game
        [SerializeField] private TextMeshProUGUI[] buttonText; // Array of UI text components for button text
        [SerializeField] private Button[] buttonColor;  // Array of UI button components for button colors

        /// <summary>
        /// Sets the initial button colors and text based on the card data.
        /// </summary>
        private void Awake()
        {
            // Set the initial button colors and text based on the card data
            for (var i = 0; i < buttonText.Length; i++)
            {
                buttonColor[i].image.color = cardController.Cards[i].material.color; // Set the button color based on the card's material color
                buttonText[i].text = cardsListForGame.Cards[i].name + "\nUpgrade: " + cardController.GameUpgrade[i]; // Set the button text based on the card name and upgrade level
            }
        }

        /// <summary>
        /// Subscribes to the tower upgrade event to update the HUD.
        /// </summary>
        private void OnEnable()
        {
           
            cardController.OnTowerUpgrade += HudController;  // Subscribe to the tower upgrade event
        }

        /// <summary>
        /// Unsubscribes from the tower upgrade event.
        /// </summary>
        private void OnDisable()
        {
           
            cardController.OnTowerUpgrade -= HudController; // Unsubscribe from the tower upgrade event
        }
        
        /// <summary>
        /// Updates the button text when a tower is upgraded.
        /// </summary>
        /// <param name="index">The index of the upgraded tower.</param>
        private void HudController(int index)
        {
            // Update the button text when a tower is upgraded
            buttonText[index].text = cardsListForGame.Cards[index].name + "\nUpgrade: " + cardController.GameUpgrade[index]; 
            // Update the button text with the card name and upgraded level
        }
    }
}
