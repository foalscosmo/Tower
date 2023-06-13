using System;
using UnityEngine;

namespace HUD.UI
{
    public class ButtonInteract : MonoBehaviour
    {
        public event Action<int> OnButtonPressed; // Event to notify when the button is pressed
        
        
        public void OnButtonClick(int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    OnButtonPressed?.Invoke(index);  // Invoke the event and pass the index as an argument
                    break;
            }
        }
    }
}
