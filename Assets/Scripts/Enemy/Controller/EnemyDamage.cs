using Interface;
using UnityEngine;

namespace Enemy.Controller
{
    /// <summary>
    /// Inflicts damage on objects implementing the IHittable interface when they enter the trigger.
    /// </summary>
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage; // Damage value
        
        /// <summary>
        /// Called when the trigger collider of this object intersects with another collider.
        /// If the other collider has an IHittable component, it receives damage.
        /// </summary>
        /// <param name="other">The collider that entered the trigger.</param>
        private void OnTriggerEnter(Collider other)
        {
            var obj = other.GetComponent<IHittable>(); // Get the component implementing the IHittable interface
            obj?.OnDamageReceived(damage);  // Invoke the OnDamageReceived method on the IHittable component if it exists
        }
    }
}