using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    public class MainGameTowers : MonoBehaviour
    {
        [SerializeField] private List<GameObject> towers; // List to store tower GameObjects
        public List<GameObject> Towers => towers; // Property to access the tower GameObjects
    }
}
