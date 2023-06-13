using System.Collections.Generic;
using TMPro;
using Tower;
using UnityEngine;

namespace HUD.Menu.Shop
{
    /// <summary>
    /// Manages the shop cards in the shop menu.
    /// </summary>
    public class ShopCards : MonoBehaviour
    {
        [SerializeField] private List<Card> cardContainer = new();  // List to store the shop cards
        [SerializeField] private ShopCardButtonContainer shopCardButtonContainer; // Reference to the container of shop card buttons
        [SerializeField] private TextMeshProUGUI[] buttonText;  // Array of UI text elements for button labels

        /// <summary>
        /// Gets the list of shop cards.
        /// </summary>
        public List<Card> CardContainer => cardContainer; 

        private void Awake()
        {
            for (var i = 0; i < buttonText.Length; i++)
            {
                shopCardButtonContainer.ShopCardButtons[i].image.color = cardContainer[i].material.color;
                // Set the button color to match the material color of the corresponding shop card
                buttonText[i].text = cardContainer[i].name + "\n Game Upgrade Price: " + cardContainer[i].gameUpgrade;
                // Set the button label text to include the shop card name and game upgrade price
                
            }
        }
    }
}