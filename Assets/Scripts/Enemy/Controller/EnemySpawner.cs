using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Controller
{
   /// <summary>
   /// Spawns and manages enemy instances in the game world.
   /// </summary>
   public class EnemySpawner : MonoBehaviour
   {
      [SerializeField] private GameObject enemy;  // Prefab of the enemy to be spawned
      [SerializeField] private Transform spawnPoint; // Point where the enemy will spawn
      [SerializeField] private Transform enemyContainer;  // Container transform to parent the spawned enemies
      [SerializeField] private int index; // Current index of spawned enemies
      private readonly List<GameObject> _enemyClone = new();  // List to store references to spawned enemies
      private GameObject _cloneEnemy;  // Reference to the clone of the enemy prefab
      private int SpawnCount { get; set; } = 2; // Number of enemies to spawn initially
      public event Action OnEnemySpawn; // Event triggered when an enemy is spawned
      public event Action OnEnemyListRemove;  // Event triggered when the enemy list is cleared
      public event Action OnEven,OnOdd; // Event triggered when SpawnCount becomes an even number, // Event triggered when SpawnCount becomes an odd number
      
      private void Start()
      {
         InvokeRepeating(nameof(InstantiateEnemy), 1, 2); // Start repeatedly spawning enemies with a delay of 1 second and an interval of 2 seconds
      }

      /// <summary>
      /// Instantiates an enemy at the spawn point and manages the spawn count and events.
      /// </summary>
      private void InstantiateEnemy()
      {
         if (index < SpawnCount)
         {
            _cloneEnemy = Instantiate(enemy, spawnPoint.transform.position, enemy.transform.rotation, enemyContainer); // Instantiate the enemy prefab at the spawn point
            _enemyClone.Add(_cloneEnemy); // Add the spawned enemy to the list
            OnEnemySpawn?.Invoke();  // Trigger the enemy spawn event
            index++;
         }
         else
         {
            if (_enemyClone[^1] != null) return;  // If the last spawned enemy is still alive, do not proceed
            RemoveEnemyList(); // Clear the enemy list
            index = 0; // Reset the index
            TakeInvokeMethod(); // Invoke the method to adjust SpawnCount and trigger events accordingly
         }
      }

      
      /// <summary>
      /// Clears the list of spawned enemies and triggers the event for a cleared enemy list.
      /// </summary>
      private void RemoveEnemyList()
      {
         _enemyClone.Clear(); // Clear the enemy list
         OnEnemyListRemove?.Invoke();  // Trigger the event for cleared enemy list
      }

      /// <summary>
      /// Adjusts the SpawnCount and triggers events based on the updated value.
      /// </summary>
      private void TakeInvokeMethod()
      {
         SpawnCount += 3; // Increase the number of enemies to spawn by 3

         if (SpawnCount % 2 == 0)
         {
            OnEven?.Invoke(); // Trigger the event for even SpawnCount
         }
         else
         {
            if (SpawnCount % 2 != 0)
            {
               OnOdd?.Invoke(); // Trigger the event for odd SpawnCount
            }
         }
      }
   }
}