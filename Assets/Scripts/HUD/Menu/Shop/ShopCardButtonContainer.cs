using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.Menu.Shop
{
    /// <summary>
    /// Container for shop card buttons.
    /// </summary>
    public class ShopCardButtonContainer : MonoBehaviour
    {
        [SerializeField] private List<Button> shopCardButtons = new();  // List of shop card buttons
        [SerializeField] private List<ShopCardInteract> shopCardInteracts = new(); // List of shop card interact components

        /// <summary>
        /// Gets the list of shop card buttons.
        /// </summary>
        public List<Button> ShopCardButtons => shopCardButtons; 
        
        /// <summary>
        /// Gets the list of shop card interact components.
        /// </summary>
        public List<ShopCardInteract> ShopCardInteracts => shopCardInteracts;
    }
}