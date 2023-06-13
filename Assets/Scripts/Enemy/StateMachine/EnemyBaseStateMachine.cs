using Enemy.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.StateMachine
{
    /// <summary>
    /// Represents the base state machine for the enemy, providing access to common components and methods.
    /// </summary>
    public class EnemyBaseStateMachine
    {
        protected readonly EnemyMovement EnemyMovement ;  // Reference to the enemy movement script
        protected readonly SkinnedMeshRenderer MeshRenderer; // Reference to the mesh renderer component
        protected readonly Material[] Material; // Array of materials for the mesh renderer
        protected readonly NavMeshAgent NavMeshAgent; // Reference to the NavMeshAgent component for pathfinding
        
          
        /// <summary>
        /// Initializes a new instance of the EnemyBaseStateMachine class with the provided references to components.
        /// </summary>
        /// <param name="enemyMovement">The enemy's movement script.</param>
        /// <param name="meshRenderer">The enemy's mesh renderer component.</param>
        /// <param name="material">The array of materials used for rendering the enemy.</param>
        /// <param name="navMeshAgent">The enemy's NavMeshAgent component for pathfinding.</param>
        protected EnemyBaseStateMachine(EnemyMovement enemyMovement,SkinnedMeshRenderer meshRenderer, 
            Material[] material, NavMeshAgent navMeshAgent)
        {
            EnemyMovement = enemyMovement;
            MeshRenderer = meshRenderer;
            Material = material;
            NavMeshAgent = navMeshAgent;
        }
   
        /// <summary>
        /// Default constructor for the EnemyBaseStateMachine class.
        /// </summary>
        public EnemyBaseStateMachine()
        {
            // Default constructor
        }
   
        /// <summary>
        /// Method called when entering a state. Should be overridden by derived classes to define specific behavior.
        /// </summary>
        public virtual void Begin()
        {
            // Method to be overridden by derived classes
        }
   
        /// <summary>
        /// Method called when exiting a state. Should be overridden by derived classes to define specific behavior.
        /// </summary>
        public virtual void End()
        {
            // Method to be overridden by derived classes
        }
    }
}