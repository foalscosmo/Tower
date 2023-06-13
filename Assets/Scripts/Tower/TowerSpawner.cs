using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> spawnPoints = new(); // List of spawn points for towers
        [SerializeField] private List<GameObject> towers = new();  // List of available tower prefabs
        [SerializeField] private MainGameTowers mainGameTowers; // Reference to the MainGameTowers component
        [SerializeField] private Transform parent;  // Parent transform for instantiated towers
        private int _pointIndex,_listCounter; // Index variable for tracking spawn points, Counter variable for spawn point list size

        private void Awake()
        {
            _listCounter = spawnPoints.Count;  // Set the counter variable to the size of the spawn point list
            for (var i = 0; i < towers.Count; i++)
            {
                towers[i] = mainGameTowers.Towers[i]; // Assign the tower from MainGameTowers to the towers list
            }
        }

       

        public void InstantiateTower()
        {
        
            var rnd = Random.Range(0, spawnPoints.Count); // Get a random index for the spawn point
            if (_pointIndex >= _listCounter) return; // If all spawn points have been used, exit the method
            Instantiate(towers[Random.Range(0, towers.Count)], // Instantiate a random tower prefab
                spawnPoints[rnd].transform.position, Quaternion.Euler(0,-180,0), parent);
            _pointIndex++; // Increment the index variable
            var plates = spawnPoints[rnd].GetComponent<MeshRenderer>(); // Get the MeshRenderer component of the spawn point
            plates.enabled = false; // Disable the MeshRenderer to hide the spawn point
            spawnPoints.RemoveAt(rnd);  // Remove the used spawn point from the list
        }
    }
}