using UnityEngine;

namespace Enemy.StateMachine
{
    /// <summary>
    /// Responsible for switching between different enemy states.
    /// </summary>
    public class StateSwitcher : MonoBehaviour
    {
        private EnemyBaseStateMachine EnemyBaseState { get; set; } = new();
    
        /// <summary>
        /// Switches the current enemy state to the specified new state.
        /// </summary>
        /// <param name="newState">The new enemy state to switch to.</param>
        public void BaseStateSwitcher(EnemyBaseStateMachine newState)
        {
            if (EnemyBaseState == newState) return; // If the new state is the same as the current state, no action is required
            EnemyBaseState.End(); // End the current state
            EnemyBaseState = newState; // Assign the new state
            EnemyBaseState.Begin(); // Begin the new state
        }
    }
}