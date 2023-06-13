using TMPro;
using UnityEngine;

namespace HUD.UI
{
    public class SetScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text; // Reference to the TextMeshProUGUI component for displaying the score
        public int CurrentScore { get; private set; } = 500; // The current score value, accessible from other scripts
        private int _scoreAmount = 10;  // The amount to increase the score by

        private void Awake()
        {
            text.text = "Score : " + CurrentScore; // Set the initial score text
        }

        public void AddScore()
        {
            CurrentScore += _scoreAmount; // Increase the current score by the score amount
            text.text = "Score : " + CurrentScore; // Update the score text
        }

        public void IncreaseScoreAmount()
        {
            _scoreAmount += 20; // Increase the score amount by 20
        }

        public void RemoveScore(int scoreAmount)
        {
            CurrentScore -= scoreAmount; // Decrease the current score by the specified score amount
            text.text = "Score : " + CurrentScore; // Update the score text
        }
    }
}
