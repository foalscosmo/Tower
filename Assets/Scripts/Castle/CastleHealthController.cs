using System;
using Interface;
using UnityEngine;

namespace Castle
{
    /// <summary>
    /// Controls the health of a castle and handles damage and healing events.
    /// </summary>
    public class CastleHealthController : MonoBehaviour, IHittable
    {
        /// <summary>
        /// The castle's health.
        /// </summary>
        public readonly CastleHealth CastleHealth = new(100, 100);
        /// <summary>
        /// Event invoked when the castle takes damage.
        /// </summary>
        public event Action<int> OnDamageTaken;
        /// <summary>
        /// Event invoked when the castle's health changes.
        /// </summary>
        public event Action<int> OnHealthTaken;
        /// <summary>
        /// Event invoked when the castle is destroyed.
        /// </summary>
        public event Action OnCastleDeath;
    
        /// <summary>
        /// Applies damage to the castle and triggers appropriate events.
        /// </summary>
        /// <param name="amount">The amount of damage to apply.</param>
        public void OnDamageReceived(int amount)
        {
            CastleHealth.Health -= amount;
            if (CastleHealth.Health != 0)
                OnDamageTaken?.Invoke(CastleHealth.Health);
            if (!(CastleHealth.Health <= 0)) return;
            OnCastleDeath?.Invoke();
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Applies health to the castle and triggers the health taken event.
        /// </summary>
        /// <param name="amount">The amount of health to apply.</param>
        public void OnHealthReceived(int amount)
        {
            CastleHealth.HealCastle(amount);
            OnHealthTaken?.Invoke(CastleHealth.Health);
        }
    }
}