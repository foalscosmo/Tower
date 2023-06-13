using Enemy.Controller;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.StateMachine
{
    /// <summary>
    /// Represents the slow state of the enemy, where it moves at a slower speed.
    /// </summary>
    public class SlowState : EnemyBaseStateMachine
    {
        /// <summary>
        /// Initializes a new instance of the SlowState class.
        /// </summary>
        /// <param name="enemyMovement">The enemy's movement component.</param>
        /// <param name="meshRenderer">The enemy's mesh renderer component.</param>
        /// <param name="materials">The materials used for rendering the enemy.</param>
        /// <param name="navMeshAgent">The enemy's NavMeshAgent component.</param>
        public SlowState(EnemyMovement enemyMovement, SkinnedMeshRenderer meshRenderer,
            Material[] materials, NavMeshAgent navMeshAgent) :
            base(enemyMovement, meshRenderer, materials, navMeshAgent)
        {
            
        }

        /// <summary>
        /// Begins the slow state, adjusting the NavMeshAgent's speed and acceleration and updating the mesh renderer's material.
        /// </summary>
        public override void Begin()
        {
          
            NavMeshAgent.speed = 30;
            NavMeshAgent.acceleration = 30;
            MeshRenderer.sharedMaterial = Material[0];
        }

        /// <summary>
        /// Ends the slow state.
        /// </summary>
        public override void End()
        {
            // This method can be used for any necessary clean-up or actions when transitioning out of the slow state.
        }
    }
}