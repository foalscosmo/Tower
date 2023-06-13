using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy.Controller
{
    /// <summary>
    /// Controls the behavior of cloned enemy objects, including their health management.
    /// </summary>
    public class EnemyCloneController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner;  // Reference to the enemy spawner
        [SerializeField] private EnemyHealthController[] childController; // Array of child enemy health controllers
        private readonly List<EnemyHealthController> _enemyHealthController = new(); // List of enemy health controllers
        public event Action<int> OnChange; // Event invoked when the enemy health changes
        private int _changeHealthTimer = 30; // Timer for changing health
        private int _increaseAmount = 20;  // Amount to increase enemy health
        
        private void OnEnable()
        {
            enemySpawner.OnEnemySpawn += AddList; // Subscribe to the enemy spawn event
            enemySpawner.OnEnemySpawn += SetHealth; // Subscribe to the enemy spawn event to set health
        }

        private void OnDisable()
        {
            enemySpawner.OnEnemySpawn -= AddList; // Unsubscribe from the enemy spawn event
            enemySpawner.OnEnemySpawn -= SetHealth; // Unsubscribe from the enemy spawn event for health setting
        }
        
        private void Update()
        {
            IncreaseHealth();  // Increase enemy health based on the timer
        }

        /// <summary>
        /// Adds the child enemy health controllers to the list of enemy health controllers.
        /// </summary>
        private void AddList()
        {
            childController = GetComponentsInChildren<EnemyHealthController>(); // Get child enemy health controllers
            for (var i = 0; i < _enemyHealthController.Count; i++)
            {
                _enemyHealthController.Add(childController[i]);  // Add child controllers to the list
            }
        }
        
        /// <summary>
        /// Sets the health of the last child controller and invokes the health change event.
        /// </summary>
        private void SetHealth()
        {
            childController.LastOrDefault()!.Health += _increaseAmount; // Increase the health of the last child controller
            OnChange?.Invoke(_increaseAmount); // Invoke the health change event
        }

        /// <summary>
        /// Increases the enemy health amount based on the timer.
        /// </summary>
        private void IncreaseHealth()
        {
            if (!(Time.time >= _changeHealthTimer)) return;  // Check if it's time to increase the health
            _increaseAmount += _increaseAmount;  // Double the increase amount
            _changeHealthTimer = (int)Time.time + 30; // Reset the timer for the next health increase
        }
    }
}
