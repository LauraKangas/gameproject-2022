using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FusilliProject
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField]
        public GameObject[] info;

        int randomSpawn;

        void Start()
        {
            SpawnInfo();
        }

        private void SpawnInfo()
        {
            // Palauttaa arvon 0 ja 17 väliltä 
            randomSpawn = Random.Range(0, 18);

            // Näyttää infotaulun numeron mukaisesti
            info[randomSpawn].SetActive(true);
        }
    }
}
