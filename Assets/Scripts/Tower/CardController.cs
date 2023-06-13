using System;
using System.Collections.Generic;
using HUD.Menu;
using UnityEngine;

namespace Tower
{
    public class CardController : MonoBehaviour
    {
        [SerializeField] private List<Card> cardContainer = new(); // List to store the tower cards
        [SerializeField] private CardsListForGame cardsListForGame;  // Reference to a CardsListForGame script
        [SerializeField] private int[] scriptableObjGameUpgrade = new int[5]; // Array to store game upgrade levels for the scriptable objects
        [SerializeField] private int[] scriptableObjHitValue = new int[5];  // Array to store hit values for the scriptable objects
        public event Action<int> OnTowerUpgrade; // Event triggered when the tower is upgraded
        public event Action<int> OnScriptableUpgrade;  // Event triggered when a scriptable object is upgraded


        public int[] GameUpgrade => scriptableObjGameUpgrade; // Property to access the game upgrade levels
        public int[] HitValue => scriptableObjHitValue; // Property to access the hit values
        
        public List<Card> Cards
        {
            get => cardContainer; // Property to get the cardContainer list
            set => cardContainer = value; // Property to set the cardContainer list
        }

        private void Awake()
        {
            // Transfer the cards from the CardsListForGame script to the cardContainer list
            for (var i = 0; i < cardsListForGame.Cards.Count; i++)
            {
                cardContainer[i] = cardsListForGame.Cards[i];
            }
            
            // Copy game upgrade levels and hit values from the cardContainer list to the corresponding arrays
            for (var i = 0; i < cardContainer.Count; i++)
            {
                scriptableObjGameUpgrade[i] = cardContainer[i].gameUpgrade;
                scriptableObjHitValue[i] = cardContainer[i].hitValue;
            }
        }

        public void UpgradeCards(int index)
        {
            switch (index)
            { 
                // Handle upgrades for card indices 0 to 4
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    // Invoke the OnScriptableUpgrade event with the current game upgrade level for the specified card index
                    OnScriptableUpgrade?.Invoke(scriptableObjGameUpgrade[index]);
                    // Double the game upgrade level and hit value for the specified card index
                    scriptableObjGameUpgrade[index] += scriptableObjGameUpgrade[index];
                    scriptableObjHitValue[index] += scriptableObjHitValue[index];
                    // Invoke the OnTowerUpgrade event with the specified card index
                    OnTowerUpgrade?.Invoke(index);
                    break;
            }
        }
    }
}
