using System;
using Castle;
using UnityEngine;

namespace Tower
{
    public class SupportTowerBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask;  // Layer mask for hit detection
        [SerializeField] private CardDisplay cardDisplay; // Reference to the CardDisplay component
        private CardController _card; // Reference to the CardController component
        private Collider[] _colliders;  // Array to store colliders
        private int _index; // Index variable for array access
        private void Awake()
        {
            
            _card = GetComponentInParent<CardController>(); // Get the CardController component from the parent object
            InvokeRepeating(nameof(SupportCollider),1f, cardDisplay.card.fireRate);  // Invoke SupportCollider method repeatedly based on fire rate
        }
        private void SupportCollider()
        {
            Func<Vector3, float, int, Collider[]> overlapSphere = Physics.OverlapSphere; // Function delegate for Physics.OverlapSphere method
            _colliders = overlapSphere(transform.position, 999999, hitMask); // Perform overlap sphere detection
            if (_colliders.Length <= 0) return; // If no colliders found, exit the method
            Func<CastleHealthController> component =
                _colliders[0].GetComponent<CastleHealthController>; // Get the CastleHealthController component from the first collider
            component().OnHealthReceived(_card.HitValue[cardDisplay.card.iD]); // Apply health to the castle
          
        }
    }
}