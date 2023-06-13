using UnityEngine;

namespace Tower
{
    public class CardDisplay : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer; // Reference to the MeshRenderer component
        public Card card; // The card data to display

        private void Awake()
        {
            // Set the color of the mesh renderer's material to match the color of the card's material
            meshRenderer.material.color = card.material.color;
        }
    }
}