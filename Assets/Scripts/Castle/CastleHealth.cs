using System;

namespace Castle
{
    /// <summary>
    /// Represents the health of a castle and provides functionality for healing the castle.
    /// </summary>
    public class CastleHealth
    {
        private readonly int _currentMaxHealth;  // The current maximum health of the castle
        private bool _stopRegenRegen; // Flag indicating whether health regeneration should stop

        /// <summary>
        /// The current health of the castle.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Initializes a new instance of the CastleHealth class with the specified health and maximum health.
        /// </summary>
        /// <param name="health">The initial health value.</param>
        /// <param name="maxHealth">The maximum health value.</param>
        public CastleHealth(int health, int maxHealth)
        {
            Health = health;
            _currentMaxHealth = maxHealth;
            CheckHealth();
        }

        /// <summary>
        /// Heals the castle by the specified amount if health is not at maximum and regeneration is not stopped.
        /// </summary>
        /// <param name="healAmount">The amount to heal the castle.</param>
        public void HealCastle(int healAmount)
        {
            if (Health < _currentMaxHealth && !_stopRegenRegen)
            {
                Health += healAmount ;
            }

            if (Health >= _currentMaxHealth)
            {
                Health = _currentMaxHealth;
            }
            CheckHealth();
        }

        /// <summary>
        /// Checks the health of the castle and determines whether health regeneration should stop.
        /// </summary>
        private void CheckHealth()
        {
            _stopRegenRegen = Math.Abs(Health - _currentMaxHealth) < 0.0001f;
        }
    }
}