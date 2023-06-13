using System;
using Enemy.Controller;
using UnityEngine;

namespace Enemy.Particle
{
    /// <summary>
    /// Controls the spawning portal behavior, including particle effects when an enemy is spawned.
    /// </summary>
    public class SpawnPortal : MonoBehaviour
    {
        [SerializeField] private EnemySpawner enemySpawner; // Reference to the enemy spawner
        [SerializeField] private new ParticleSystem particleSystem; // Reference to the particle system

        private void Awake()
        {
            particleSystem.Stop();  // Stop the particle system initially
            enemySpawner.OnEnemySpawn += ParticleOn; // Subscribe to the event for enemy spawn
        }

        private void OnDisable()
        {
            enemySpawner.OnEnemySpawn -= ParticleOn; // Unsubscribe from the event for enemy spawn
        }

        /// <summary>
        /// Play the particle system when an enemy is spawned.
        /// </summary>
        private void ParticleOn()
        {
            particleSystem.Play(); // Play the particle system when an enemy is spawned
        }
    }
}
