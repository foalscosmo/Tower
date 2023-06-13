using UnityEngine;

namespace Tower
{
    public class DetectionWithRay : MonoBehaviour
    {
        [SerializeField] private LayerMask hitMask;  // Layer mask to filter which objects can be detected
        private RaycastHit _hit;  // RaycastHit to store information about the detected object
        
        public RaycastHit Hit => _hit; // Property to access the RaycastHit

        private void Awake()
        {
            InvokeDetection(); // Invoke the initial detection
        }

        private void InvokeDetection()
        { 
            InvokeRepeating(nameof(Detection), 1,0.01f); // Invoke the Detection method repeatedly with a delay and interval
        }

        private void Detection()
        {
            // Perform a raycast from a position slightly below the transform's position, in the forward direction
            // Store the result in the _hit variable if an object is hit within the specified distance and matches the hitMask
            if (!Physics.Raycast(new Vector3(transform.position.x,
                        transform.position.y - 5f, transform.position.z),
                    transform.forward,
                    out _hit, 99999, hitMask)){}  // If no object is hit, do nothing
        }
    }
}
    
