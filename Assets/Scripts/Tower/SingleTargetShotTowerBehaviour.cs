using System;
using Enemy.Controller;
using UnityEngine;

namespace Tower
{
    public class SingleTargetShotTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask; // Layer mask for hit detection
        [SerializeField] private CardDisplay cardDisplay; // Reference to the CardDisplay component
        private CardController _card; // Reference to the CardController component
        private Collider[] _colliders; // Array to store colliders
        private Vector3 _direction; // Direction vector for rotation

        private void Awake()
        {
            _card = GetComponentInParent<CardController>(); // Get the CardController component from the parent object
            InvokeRepeating(nameof(DamageCollider),1f, cardDisplay.card.fireRate); // Invoke DamageCollider method repeatedly based on fire rate
        }
        
        private void DamageCollider()
        {
            Func<Vector3, float, int, Collider[]> overlapSphere = Physics.OverlapSphere;  // Function delegate for Physics.OverlapSphere method
            _colliders = overlapSphere(transform.position, 999999, hitMask);  // Perform overlap sphere detection
            if (_colliders.Length <= 0) return; // If no colliders found, exit the method
            Func<DetectionWithRay> colliderObj = _colliders[0].GetComponent<DetectionWithRay>; // Get the DetectionWithRay component from the first collider
            _direction = colliderObj().transform.position - transform.position; // Calculate the direction vector
            _direction.y = 0;  // Set the y-component of the direction vector to zero
            if (!Physics.Raycast(new Vector3(transform.position.x,
                        transform.position.y, transform.position.z),
                    _direction,
                    out var hit, 9999, hitMask)) return;  // Perform a raycast to check for obstruction
                
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(_direction),1f ).normalized; // Rotate the tower to face the target
                
            Func<DetectionWithRay> rayHit = hit.transform.GetComponent<DetectionWithRay>; // Get the DetectionWithRay component from the raycast hit object
                
            if (rayHit().Hit.transform == null) return; // If the raycast hit object has no transform, exit the method
            Func<EnemyHealthController> hitObj = rayHit().Hit.transform.GetComponent<EnemyHealthController>; // Get the EnemyHealthController component from the raycast hit object
            hitObj().OnDamageReceived(_card.HitValue[cardDisplay.card.iD]); // Apply damage to the enemy
        }
    }
}