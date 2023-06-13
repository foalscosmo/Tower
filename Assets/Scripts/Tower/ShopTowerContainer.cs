using System.Collections.Generic;
using HUD.Menu.Shop;
using UnityEngine;

namespace Tower
{
    public class ShopTowerContainer : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabTowers = new(); // List of prefab tower GameObjects
        [SerializeField] private List<GameObject> chosenTowers = new(); // List of chosen tower GameObjects
        [SerializeField] private List<ShopCardInteract> menuCardInteracts; // List of menu card interact components
        [SerializeField] private MainGameTowers mainGameTowers; // Reference to the MainGameTowers component
        [SerializeField] private SelectedCards selectedCards;  // Reference to the SelectedCards component

        private void Awake()
        {
            // Set each element in the mainGameTowers.Towers list to null
            for (var i = 0; i < chosenTowers.Count; i++)
            {
                mainGameTowers.Towers[i] = null;
            }
        }

        private void OnEnable()
        {
            // Subscribe to the OnShopCardPressed event of each menu card interact component
            foreach (var t in menuCardInteracts)
            {
                t.OnShopCardPressed += AddToGameTowers;
            }
        }
        
        private void OnDisable()
        {
            // Unsubscribe from the OnShopCardPressed event of each menu card interact component
            foreach (var t in menuCardInteracts)
            {
                t.OnShopCardPressed -= AddToGameTowers;
            }
        }

        public void SetInGameTowers()
        {
            // Set the tower GameObjects in the mainGameTowers.Towers list based on the chosenTowers list
            for (var i = 0; i < mainGameTowers.Towers.Count; i++)
            {
                mainGameTowers.Towers[i] = chosenTowers[i];
            }
        }

        private void AddToGameTowers(int index)
        {   
            // Add the selected prefab tower GameObject to the chosenTowers list at the selectedCards.Number index
            chosenTowers[selectedCards.Number] = prefabTowers[index];
        }
        
        public void RemoveCard(int index)
        {
            // Set the tower GameObject at the specified index in the chosenTowers list to null
            chosenTowers[index] = null;
        }
    }
}
