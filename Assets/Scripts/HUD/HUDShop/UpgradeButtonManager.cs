using System.Collections.Generic;
using HUD.UI;
using TMPro;
using Tower;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.HUDShop
{
    /// <summary>
    /// Manages the upgrade buttons UI interaction and functionality.
    /// </summary>
    public class UpgradeButtonManager : MonoBehaviour
    {
        [SerializeField] private SetScore setScore; // Reference to the SetScore component
        [SerializeField] private CardController cardController; // Reference to the CardController component
        [SerializeField] private List<Button> button = new(); // List of upgrade buttons
        [SerializeField] private List<ButtonInteract> buttonInteracts = new();  // List of ButtonInteract components
        [SerializeField] private TextMeshProUGUI[] textMeshProUgui;  // Array of TextMeshProUGUI components
        [SerializeField] private int[] clickCount;  // Array of click counts for each button
        [SerializeField] private int[] maxClick; // Array of maximum click counts for each button
    
        /// <summary>
        /// Subscribes to the button pressed events of the upgrade buttons when the object becomes enabled.
        /// </summary>
        private void OnEnable()
        {
            for (var i = 0; i < buttonInteracts.Count - 1; i++) buttonInteracts[i].OnButtonPressed += UpgradeButtonInteract;
            // Subscribe to the button pressed events
        }

        /// <summary>
        /// Unsubscribes from the button pressed events of the upgrade buttons when the object becomes disabled.
        /// </summary>
        private void OnDisable()
        {
           
            for (var i = 0; i < buttonInteracts.Count - 1; i++) buttonInteracts[i].OnButtonPressed -= UpgradeButtonInteract;
            // Unsubscribe from the button pressed events

        }

        
        /// <summary>
        /// Updates the intractability of each upgrade button based on the current score and upgrade cost.
        /// </summary>
        private void Update()
        {
          
            for (var i = 0; i < button.Count; i++)
            {
                button[i].interactable = setScore.CurrentScore >= cardController.GameUpgrade[i];
                // Enable or disable the button based on the current score and upgrade cost
            }
        }

        /// <summary>
        /// Handles the interaction when an upgrade button is pressed.
        /// </summary>
        /// <param name="number">The index of the upgrade button pressed.</param>
        public void UpgradeButtonInteract(int number)
        {
            switch (number)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    clickCount[number]++; // Increase the click count for the corresponding button
                    if (clickCount[number] >= maxClick[number])
                    {
                        button[number].interactable = false;  // Disable the button if the maximum click count is reached
                        textMeshProUgui[number].text = "Max Stack"; // Update the text to indicate the maximum is reached
                    }
                    break;
            }
        }
    }
}