using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy.Controller
{
    /// <summary>
    /// Updates the UI text component with the enemy's health information.
    /// </summary>
    public class EnemyUi : MonoBehaviour
    {
        [SerializeField] private EnemyHealthController enemyHealthController;  // Reference to the enemy's health controller
        [SerializeField] private EnemyCloneController enemyCloneController;  // Reference to the enemy's clone controller
        [SerializeField] private TextMeshPro text; // Reference to the UI text component

        private void Start()
        {
            text.text = enemyHealthController.Health.ToString(); // Set the initial text value to the enemy's current health
            enemyHealthController.OnDamageTaken += SetText; // Subscribe to the event for when the enemy takes damage
            enemyHealthController.OnHealthTaken += SetText; // Subscribe to the event for when the enemy's health changes
            enemyCloneController.OnChange += SetText; // Subscribe to the event for when the enemy clone controller changes
        }

        private void OnDestroy()
        {
            enemyHealthController.OnDamageTaken -= SetText; // Unsubscribe from the event for enemy damage taken
            enemyHealthController.OnHealthTaken -= SetText; // Unsubscribe from the event for enemy health taken
            enemyCloneController.OnChange -= SetText; // Unsubscribe from the event for enemy clone controller changes
        }

        /// <summary>
        /// Sets the UI text to the provided amount.
        /// </summary>
        /// <param name="amount">The value to display in the UI text.</param>
        private void SetText(int amount)
        {
            text.text = amount.ToString(); // Update the UI text with the provided amount
        }
    }
}