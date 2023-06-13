using TMPro;
using UnityEngine;

namespace Castle
{
    /// <summary>
    /// Updates the UI text for the castle's health and subscribes to health-related events.
    /// </summary>
    public class CastleUi : MonoBehaviour
    {
        [SerializeField] private TextMeshPro text;  // Reference to the UI text component
        [SerializeField] private CastleHealthController castleHealthController;  // Reference to the castle's health controller
    
        /// <summary>
        /// Subscribes to health-related events and updates the UI text with the castle's initial health.
        /// </summary>
        private void OnEnable()
        {
            text.text = castleHealthController.CastleHealth.Health.ToString();  // Set the initial UI text to the castle's health
            castleHealthController.OnDamageTaken += SetText;  // Subscribe to the event for when the castle takes damage
            castleHealthController.OnHealthTaken += SetText;  // Subscribe to the event for when the castle's health changes
        }

        /// <summary>
        /// Unsubscribes from health-related events.
        /// </summary>
        private void OnDestroy()
        {
            castleHealthController.OnDamageTaken += SetText;  // Unsubscribe from the event for castle damage taken
            castleHealthController.OnHealthTaken -= SetText;  // Unsubscribe from the event for castle health taken
        }

        
        /// <summary>
        /// Updates the UI text with the provided amount.
        /// </summary>
        /// <param name="amount">The amount to update the UI text.</param>
        private void SetText(int amount)
        {
            text.text = amount.ToString(); // Update the UI text with the provided amount
        }
        }
    }
