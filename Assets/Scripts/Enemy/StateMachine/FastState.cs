using Enemy.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.StateMachine
{
    /// <summary>
    /// Represents the fast state of the enemy, where it moves at a higher speed.
    /// </summary>
    public class FastState : EnemyBaseStateMachine
    {
        /// <summary>
        /// Initializes a new instance of the FastState class.
        /// </summary>
        /// <param name="enemyMovement">The enemy's movement component.</param>
        /// <param name="meshRenderer">The enemy's mesh renderer component.</param>
        /// <param name="materials">The materials used for rendering the enemy.</param>
        /// <param name="navMeshAgent">The enemy's NavMeshAgent component.</param>
        public FastState(EnemyMovement enemyMovement, SkinnedMeshRenderer meshRenderer, 
            Material[] materials, NavMeshAgent navMeshAgent) :
            base(enemyMovement, meshRenderer, materials, navMeshAgent)
        {
            // Constructor calls the base class constructor to initialize the component references
        }
        
        /// <summary>
        /// Begins the fast state, adjusting the NavMeshAgent's speed and acceleration and updating the mesh renderer's material.
        /// </summary>
        public override void Begin()
        {
            NavMeshAgent.speed = 50;  // Set the NavMeshAgent speed to 50
            NavMeshAgent.acceleration = 50; // Set the NavMeshAgent acceleration to 50
            MeshRenderer.sharedMaterial = Material[1]; // Set the material of the mesh renderer to the second material in the array
        }

        /// <summary>
        /// Ends the fast state.
        /// </summary>
        public override void End()
        {
            // This method can be used for any necessary clean-up or actions when transitioning out of the fast state.
        }
    }
}