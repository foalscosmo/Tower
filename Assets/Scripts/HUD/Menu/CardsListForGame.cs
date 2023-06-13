using System.Collections.Generic;
using Tower;
using UnityEngine;

namespace HUD.Menu
{
    public class CardsListForGame : MonoBehaviour
    {
        [SerializeField] private List<Card> cards;  // List of cards for the game
        [SerializeField] private List<int> number; // List of numbers associated with each card
        public List<Card> Cards => cards; // Property to access the list of cards
        public List<int> Number => number;  // Property to access the list of numbers
    }
}
