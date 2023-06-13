using UnityEngine;

namespace Tower
{
    // Enum representing different card types
    public enum Cards
    {
        Common,
        UnCommon,
        Rear,
        Epic,
        Legendary
    }
    
    // ScriptableObject class representing a tower card
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards/Tower")]
    public class Card : ScriptableObject
    {
        public Cards cards; // The type of the card (from the Cards enum)
        public new string name;  // The name of the card
        [TextArea(5,10)] 
        public string description; // The description of the card
        public int iD; // The ID of the card
        public int hitValue; // The hit value or damage of the card
        public float fireRate;   // The fire rate of the card
        public int gameUpgrade;  // The upgrade level of the card in the game
        public Material material;  // The material of the card (used for rendering)
    }
}