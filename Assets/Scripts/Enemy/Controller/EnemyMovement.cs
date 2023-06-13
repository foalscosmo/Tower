using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Controller
{
    /// <summary>
    /// Controls the movement of an enemy using a NavMeshAgent component.
    /// </summary>
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navmesh;  // Reference to the NavMeshAgent component
        [SerializeField] private Transform target;  // Target transform the enemy will move towards

        /// <summary>
        /// Gets or sets the NavMeshAgent component for controlling the enemy's movement.
        /// </summary>
        public NavMeshAgent NavMeshAgent
        {
            get => navmesh;
            set => navmesh = value;
        }

        /// <summary>
        /// Updates the enemy's movement by setting the destination of the NavMeshAgent to the target position.
        /// </summary>
        private void Update()
        {
            navmesh.SetDestination(target.transform.position);  // Set the destination of the NavMeshAgent to the target position
        }
    }
}