
using Castle;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Reference to a UI panel object
    [SerializeField] private GameObject resume; // Reference to a UI button object used to resume the game
    [SerializeField] private GameObject[] hudButtons; // Array of UI button objects used in the heads-up display (HUD)
    [SerializeField] private CastleHealthController castleHealthController; // Reference to a CastleHealthController script
  

    private void Awake()
    {
        panel.SetActive(false); // Deactivate the panel object on awake
        castleHealthController.OnCastleDeath += RemotePanel; // Subscribe to the OnCastleDeath event of the CastleHealthController script
    }

    private void OnDisable()
    {
        castleHealthController.OnCastleDeath -= RemotePanel; // Unsubscribe from the OnCastleDeath event of the CastleHealthController script
    }


    public void ResetGame()
    {
        Time.timeScale = 1; // Set the time scale to normal
        SceneManager.LoadScene("GameScene");  // Load the "GameScene" scene
    }

    public void ExitGame()
    {
        Application.Quit(); // Quit the application
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("ShopScene");  // Load the "ShopScene" scene
    }

    private void RemotePanel()
    {
        panel.SetActive(true); // Activate the panel object
        resume.SetActive(false); // Deactivate the resume button object
        foreach (var t in hudButtons) t.SetActive(false); // Deactivate each button in the hudButtons array
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Set the time scale to 0 (pause the game)
        panel.SetActive(true); // Activate the panel object
        foreach (var t in hudButtons) t.SetActive(false);  // Deactivate each button in the hudButtons array
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Set the time scale to normal
        panel.SetActive(false);  // Deactivate the panel object
        foreach (var t in hudButtons) t.SetActive(true);  // Activate each button in the hudButtons array
    }
    }

  
