using HUD.Menu.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.UI
{
    public class HUDButtonController : MonoBehaviour
    {
        [SerializeField] private SelectedCards selectedCards; // Reference to the SelectedCards component
        [SerializeField] private Button playButton;  // Reference to the play button

        private void OnEnable()
        {
            selectedCards.OnListCheck += SetButtonInteract; // Subscribe to the OnListCheck event of the SelectedCards component
        }

        private void OnDisable()
        {
            selectedCards.OnListCheck -= SetButtonInteract; // Unsubscribe from the OnListCheck event of the SelectedCards component
        }

        private void SetButtonInteract(int index)
        {
            // Set the interactable state of the playButton based on the index value using a switch statement
            playButton.interactable = index switch
            {
                0 => false, // If index is 0, set the interactable state of the playButton to false
                1 => true,   // If index is 1, set the interactable state of the playButton to true
                _ => playButton.interactable // For any other index value, maintain the current interactable state of the playButton
            };
        }
    }
}
