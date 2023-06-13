
using TMPro;
using UnityEngine;

namespace HUD.UI
{
    // WaveManager class derived from MonoBehaviour
    public class WaveManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;  // Serialized field for the TextMeshProUGUI component
        private int WaveNumber { get; set; } = 1;  // Private property for the wave number, initialized to 1

        // Awake method is called when the script instance is being loaded
        private void Awake()
        {
            text.text = "Wave Number: " + WaveNumber; // Set the initial text to display the wave number
        }

        // Public method to add a wave
        public void AddWave()
        {
            WaveNumber++; // Increment the wave number
            text.text = "Wave Number: " + WaveNumber; // Update the text to display the updated wave number
        }
    }
}
