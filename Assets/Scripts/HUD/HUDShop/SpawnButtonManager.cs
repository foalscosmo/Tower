using System;
using HUD.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.HUDShop
{
    /// <summary>
    /// Manages the spawn button UI interaction and functionality.
    /// </summary>
    public class SpawnButtonManager : MonoBehaviour
    {
        [SerializeField] private ButtonInteract buttonInteracts;  // Reference to the ButtonInteract component
        [SerializeField] private SetScore setScore;  // Reference to the SetScore component
        [SerializeField] private Button button;  // Reference to the Button component
        [SerializeField] private TextMeshProUGUI textMeshProUGUI; // Reference to the TextMeshProUGUI component
        [SerializeField] private int clickCount; // Counter for the number of button clicks
        public event Action<int> OnSpawnButton;  // Event triggered when the spawn button is pressed
        private const int MaxClick = 10; // Maximum number of clicks allowed
        private const int SpawnPrice = 50; // Cost of spawning

        /// <summary>
        /// Subscribes to the button pressed event when the object becomes enabled.
        /// </summary>
        private void OnEnable()
        {
            buttonInteracts.OnButtonPressed += SpawnButtonInteract;  // Subscribe to the button pressed event
        }

        /// <summary>
        /// Unsubscribes from the button pressed event when the object becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            buttonInteracts.OnButtonPressed += SpawnButtonInteract;  // Unsubscribe from the button pressed event
        }

        
        /// <summary>
        /// Updates the button's interactivity based on the current score.
        /// </summary>
        private void Update()
        {
            button.interactable = setScore.CurrentScore >= SpawnPrice;  // Enable or disable the button based on the current score
        }

        /// <summary>
        /// Handles the interaction when the spawn button is pressed.
        /// </summary>
        /// <param name="index">The index of the button pressed.</param>
        private void SpawnButtonInteract(int index)
        {
            clickCount++;  // Increase the click count
            OnSpawnButton?.Invoke(SpawnPrice); // Invoke the OnSpawnButton event with the spawn price

            if (clickCount < MaxClick) return; // If the maximum click count is not reached, exit the method
            button.interactable = false; // Disable the button
            textMeshProUGUI.text = "Max";  // Update the text to indicate the maximum is reached
        }
    }
}