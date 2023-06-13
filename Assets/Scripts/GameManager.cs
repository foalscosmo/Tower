using Enemy.Controller;
using HUD.HUDShop;
using HUD.UI;
using Tower;
using UnityEngine;

/*
The `GameManager` class is responsible for managing various components in the game. It is a MonoBehaviour and serves as a singleton, ensuring that only one instance of `GameManager` exists.

The class has references to several components: `SetScore`, `EnemySpawner`, `CardController`, and `SpawnButtonManager`. These components are serialized fields and can be assigned in the Unity inspector.

In the `Awake()` method, the code checks if an instance of `GameManager` already exists. If it does, the current instance is destroyed to enforce the singleton pattern. Otherwise, the `Manager` property is set to this instance.

In the `OnEnable()` method, event handlers for score-related events are registered. These events include `OnEnemyListRemove` from `EnemySpawner`, `OnScriptableUpgrade` from `CardController`, and `OnSpawnButton` from `SpawnButtonManager`. The corresponding methods from the `SetScore` component are assigned as event handlers.

In the `OnDisable()` method, the event handlers are unregistered to prevent memory leaks and ensure proper cleanup.

Overall, the `GameManager` class provides centralized management for game components and handles score-related events by interacting with the `SetScore` component.
*/
public class GameManager : MonoBehaviour
{
    private GameManager Manager { get; set; }  // Reference to the GameManager instance
    [SerializeField] private SetScore setScore; // Reference to the SetScore component
    [SerializeField] private EnemySpawner enemySpawner; // Reference to the EnemySpawner component
    [SerializeField] private CardController cardController; // Reference to the CardController component
    [SerializeField] private SpawnButtonManager spawnButtonManager; // Reference to the SpawnButtonManager component
    [SerializeField] private WaveManager waveManager;  // Reference to the WaveManager component

    private void Awake()
    {
        if (Manager != null && Manager != this) Destroy(this); // Ensure only one instance of GameManager exists
        else Manager = this;  // Set the GameManager reference to this instance
    }
    
    private void OnEnable()
    { 
        // Register event handlers for score-related events
        enemySpawner.OnEnemyListRemove += setScore.AddScore;
        enemySpawner.OnEnemyListRemove += setScore.IncreaseScoreAmount;
        cardController.OnScriptableUpgrade += setScore.RemoveScore;
        spawnButtonManager.OnSpawnButton += setScore.RemoveScore;
        enemySpawner.OnEnemyListRemove += waveManager.AddWave;
    }

    private void OnDisable()
    {   
        // Unregister event handlers for score-related events
        enemySpawner.OnEnemyListRemove -= setScore.AddScore;
        enemySpawner.OnEnemyListRemove -= setScore.IncreaseScoreAmount;
        cardController.OnScriptableUpgrade -= setScore.RemoveScore;
        spawnButtonManager.OnSpawnButton -= setScore.RemoveScore;
        enemySpawner.OnEnemyListRemove -= waveManager.AddWave;
    }
    
}