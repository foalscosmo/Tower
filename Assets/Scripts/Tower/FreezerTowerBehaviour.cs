using System;
using Enemy.Controller;
using UnityEngine;

namespace Tower
{
    public class FreezerTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask; // Layer mask to filter which objects can be hit
        [SerializeField] private CardDisplay cardDisplay; // Reference to a CardDisplay script
        private CardController _card; // Reference to a CardController script
        private Collider[] _colliders; // Array to store colliders of detected objects

        private void Awake()
        {
            _card = GetComponentInParent<CardController>();  // Get the CardController component from the parent
            InvokeRepeating(nameof(FreezerCollider),1f, cardDisplay.card.fireRate); // Invoke the FreezerCollider method repeatedly with a delay and interval based on the card's fire rate
        }
        
        private void FreezerCollider()
        {   // Define a function to perform an overlap sphere check
            Func<Vector3, float, int, Collider[]> overlapSphere = Physics.OverlapSphere;
            
            // Perform the overlap sphere check around the transform's position with the specified radius, using the hitMask
            _colliders = overlapSphere(transform.position, 999999, hitMask);
            
            // Check if any colliders are detected
            if (_colliders.Length <= 0) return; // If no colliders are detected, exit the method
            
            // Loop through each detected collider
            foreach (var t in _colliders)
            {   // Get the EnemyMovement component from the collider
                Func<EnemyMovement> speed = t.GetComponent<EnemyMovement>;
                
                // Reduce the speed of the enemy by the hit value of the card
                speed().NavMeshAgent.speed -= _card.HitValue[cardDisplay.card.iD];
                
                // Get the EnemyHealthController component from the collider
                Func<EnemyHealthController> dmgComponent = t.GetComponent<EnemyHealthController>;
                
                // Apply damage to the enemy based on the hit value of the card
                dmgComponent().OnDamageReceived(_card.HitValue[cardDisplay.card.iD]);
            }
        }
    }
}