using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Blackboard : MonoBehaviour
    {
        public GameObject Player { get { return player; } }
        public List<Flammable> Flammables { get; private set; }

        [SerializeField]
        private GameObject player;

        private void Start()
        {
            Flammables = new List<Flammable>(FindObjectsOfType<Flammable>());
        }

        private void Update()
        {

        }

    }
}