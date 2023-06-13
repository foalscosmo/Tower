using Enemy.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.StateMachine
{
    /// <summary>
    /// Manages the switching of enemy states based on events triggered by the enemy spawner.
    /// </summary>
    public class CurrentStateSwitcher : MonoBehaviour
    {
        [SerializeField] private EnemyMovement movement;  // Reference to the enemy's movement script
        [SerializeField] private SkinnedMeshRenderer meshRenderer; // Reference to the enemy's mesh renderer component
        [SerializeField] private Material[] material;  // Array of materials to be applied to the enemy's mesh renderer
        [SerializeField] private EnemySpawner enemySpawner; // Reference to the enemy spawner script
        [SerializeField] private StateSwitcher stateSwitcher; // Reference to the state switcher script
        [SerializeField] private NavMeshAgent navMeshAgent; // Reference to the enemy's NavMeshAgent component for pathfinding
        private StateFactory _stateFactory;  // Instance of the state factory to create different enemy states

        /// <summary>
        /// Called before the first frame update. Initializes the state factory and subscribes to enemy spawner events.
        /// </summary>
        private void Awake()
        {
            _stateFactory = new StateFactory(movement,meshRenderer, material, navMeshAgent); // Create an instance of the state factory
            enemySpawner.OnEven += Fast; // Subscribe to the event triggered on even enemy spawns
            enemySpawner.OnOdd += Slow; // Subscribe to the event triggered on odd enemy spawns
        }

        /// <summary>
        /// Called when the script is being destroyed. Unsubscribes from enemy spawner events.
        /// </summary>
        private void OnDestroy()
        {
            enemySpawner.OnEven -= Fast; // Unsubscribe from the event triggered on even enemy spawns
            enemySpawner.OnOdd -= Slow; // Unsubscribe from the event triggered on odd enemy spawns
        }
        
        /// <summary>
        /// Switches the enemy state to a fast state when an even enemy spawn event occurs.
        /// </summary>
        private void Fast()
        {
            stateSwitcher.BaseStateSwitcher(_stateFactory.Fast()); // Switch the enemy state to a fast state using the state factory
        }

        /// <summary>
        /// Switches the enemy state to a slow state when an odd enemy spawn event occurs.
        /// </summary>
        private void Slow()
        {
            stateSwitcher.BaseStateSwitcher(_stateFactory.Slow()); // Switch the enemy state to a slow state using the state factory
        }
    }
}