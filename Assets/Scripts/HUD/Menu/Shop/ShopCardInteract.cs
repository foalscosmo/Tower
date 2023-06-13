using System;
using UnityEngine;

namespace HUD.Menu.Shop
{
    
    /// <summary>
    /// Handles the interaction of a shop card button.
    /// </summary>
    public class ShopCardInteract : MonoBehaviour
    {
        /// <summary>
        /// Handles the button press event.
        /// </summary>
        public event Action<int> OnShopCardPressed; 
        public void Buttons(int index)
        {
            OnShopCardPressed?.Invoke(index); 
        }
    }
}