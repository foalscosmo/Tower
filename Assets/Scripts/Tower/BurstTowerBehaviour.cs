using System;
using Enemy.Controller;
using UnityEngine;

namespace Tower
{
    public class BurstTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask; // Layer mask to filter which objects can be hit by the burst tower
        [SerializeField] private CardDisplay cardDisplay; // Reference to a CardDisplay script
        private CardController _card; // Reference to a CardController script
        private Collider[] _colliders; // Array to store colliders that overlap with the burst tower
        private Vector3 _direction; // Direction vector used for calculations

        private void Awake()
        {
            _card = GetComponentInParent<CardController>(); // Get the CardController component from the parent object
            InvokeRepeating(nameof(BurstCollider),1f, cardDisplay.card.fireRate); // Invoke BurstCollider method repeatedly with a delay and interval based on the fire rate of the card
        }
        
        private void BurstCollider()
        {
            Func<Vector3, float, int, Collider[]> overlapSphere = Physics.OverlapSphere;  // Define a function to perform an overlap sphere check
            _colliders = overlapSphere(transform.position, 999999, hitMask); // Perform an overlap sphere check around the burst tower position using the hitMask to filter colliders
            if (_colliders.Length <= 0) return; // If no colliders are found, exit the method
            foreach (var t in _colliders)
            {
                var enemyHealthController = t.GetComponent<EnemyHealthController>(); // Get the EnemyHealthController component from the colliders game object
                _direction = t.transform.position - transform.position;  // Calculate the direction vector from the burst tower to the colliders position
                _direction.y = 0; // Ignore the vertical component of the direction vector
                if (!(Vector3.Angle(-transform.forward,_direction) < 30)) return;  // If the angle between the burst tower's forward direction and the direction vector is not less than 30 degrees, exit the loop
                enemyHealthController.OnDamageReceived(_card.HitValue[cardDisplay.card.iD]); // Call the OnDamageReceived method of the enemy health controller and pass the hit value based on the card's ID
            }
        }
    }
}