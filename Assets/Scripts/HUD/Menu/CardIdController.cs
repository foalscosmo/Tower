using UnityEngine;

namespace HUD.Menu
{
    /// <summary>
    /// Controls the assignment of IDs to cards in the HUD menu.
    /// </summary>
    public class CardIdController : MonoBehaviour
    {
        [SerializeField] private CardsListForGame cardsListForGame; // Reference to the CardsListForGame component

        /// <summary>
        /// Updates the IDs of the cards based on their corresponding numbers.
        /// </summary>
        private void LateUpdate()
        {
            for (var i = 0; i < cardsListForGame.Cards.Count; i++)
            {
                if (cardsListForGame.Cards[i] is not null) // Check if the card at the current index exists
                {
                    cardsListForGame.Cards[i].iD = cardsListForGame.Number[i];  // Assign the corresponding number as the ID for the card
                }
            }
        }
    }
}