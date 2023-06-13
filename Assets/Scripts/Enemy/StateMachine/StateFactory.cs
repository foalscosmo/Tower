using System.Collections.Generic;
using Enemy.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.StateMachine
{
   
    public enum States
    {
        SlowEnemy,
        FastEnemy
    }
    /// <summary>
    /// Factory class responsible for creating different enemy states based on the provided parameters.
    /// </summary>
    public class StateFactory
    {
        private readonly Dictionary<States, EnemyBaseStateMachine> _container = new();
        
        /// <summary>
        /// Initializes the state factory and creates instances of different enemy states.
        /// </summary>
        /// <param name="enemyMovement">The enemy's movement script.</param>
        /// <param name="meshRenderers">The enemy's mesh renderer component.</param>
        /// <param name="materials">The array of materials to be applied to the enemy's mesh renderer.</param>
        /// <param name="navMeshAgent">The enemy's NavMeshAgent component for pathfinding.</param>
        public StateFactory(EnemyMovement enemyMovement, SkinnedMeshRenderer meshRenderers,
            Material[] materials, NavMeshAgent navMeshAgent)
        {
            _container[States.SlowEnemy] = new SlowState(enemyMovement, meshRenderers, materials, navMeshAgent);  // Create an instance of the SlowState
            _container[States.FastEnemy] = new FastState(enemyMovement, meshRenderers, materials, navMeshAgent); // Create an instance of the FastState
        }
        /// <summary>
        /// Creates and returns an instance of the FastState.
        /// </summary>
        /// <returns>An instance of the FastState.</returns>
        public EnemyBaseStateMachine Fast()
        { 
            return _container[States.FastEnemy];  // Return the instance of the FastState from the dictionary
        }
        /// <summary>
        /// Creates and returns an instance of the SlowState.
        /// </summary>
        /// <returns>An instance of the SlowState.</returns>
        public EnemyBaseStateMachine Slow()
        {
            return _container[States.SlowEnemy]; // Return the instance of the SlowState from the dictionary
        }
    
    }
}