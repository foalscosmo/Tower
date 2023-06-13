using System;
using Interface;
using UnityEngine;

namespace Enemy.Controller
{
    /// <summary>
    /// Controls the health of an enemy and provides methods for taking damage and gaining health.
    /// Implements the IHittable interface for receiving damage from other objects.
    /// </summary>
    public class EnemyHealthController : MonoBehaviour, IHittable
    {
        [SerializeField] private int currentHealth; // Current health value
        public event Action<int> OnDamageTaken; // Event invoked when damage is taken
        public event Action<int> OnHealthTaken;  // Event invoked when health is gained

        /// <summary>
        /// Gets or sets the current health value.
        /// </summary>
        public int Health
        {
            get => currentHealth;
            set => currentHealth = value;
        }

        /// <summary>
        /// Reduces the enemy's health by the specified amount.
        /// If the health is not zero, invokes the OnDamageTaken event with the current health.
        /// If the health reaches or falls below zero, destroys the game object.
        /// </summary>
        /// <param name="amount">The amount of damage to be taken.</param>
        public void OnDamageReceived(int amount)
        {
            currentHealth -= amount;  // Reduce health by the specified amount
            if (currentHealth != 0) 
                OnDamageTaken?.Invoke(currentHealth); // Invoke the OnDamageTaken event, passing the current health
            if (!(currentHealth <= 0)) return; 
            Destroy(gameObject); // If health reaches or falls below 0, destroy the game object
        }

        /// <summary>
        /// Increases the enemy's health by the specified amount.
        /// Invokes the OnHealthTaken event with the current health.
        /// </summary>
        /// <param name="amount">The amount of health to be gained.</param>
        public void OnHealthReceived(int amount)
        {
            currentHealth += amount; // Increase health by the specified amount
            OnHealthTaken?.Invoke(currentHealth);  // Invoke the OnHealthTaken event, passing the current health
        }
        
        /// <summary>
        /// Automatically takes damage when colliding with another collider.
        /// </summary>
        /// <param name="other">The collider that was collided with.</param>
        private void OnTriggerEnter(Collider other)
        {
            OnDamageReceived(currentHealth); // Automatically take damage when colliding with another collider
        }
    }
}

