using UnityEngine;
using UnityEngine.UI;

namespace HUD.UI
{
   public class VolumeButton : MonoBehaviour
   {
      [SerializeField] private Sprite[] image; // Array of sprites for different button states
      [SerializeField] private Image currentImage; // Reference to the Image component for displaying the button sprite
      [SerializeField] private new AudioSource audio;  // Reference to the AudioSource component for controlling the volume
      private bool _isTurn; // Flag indicating the current state of the volume

      private void Awake()
      {
         _isTurn = true; // Set the initial state of the volume
      }

      public void TurnMusic()
      {
     
         switch (_isTurn)
         {
            case true:
               currentImage.sprite = image[0]; // Set the sprite to the "off" state
               _isTurn = false; // Update the volume state
               audio.volume = 0;  // Mute the audio by setting volume to 0
               break; 
            case false:
               currentImage.sprite = image[1]; // Set the sprite to the "on" state
               _isTurn = true; // Update the volume state
               audio.volume = 1;  // Set the volume to maximum (1)
               break;
         }
      }
   }
}
