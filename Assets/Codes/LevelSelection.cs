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
			randomSpawn = Random.Range(1,18);

			info[randomSpawn].SetActive(true);

			
        }
    }
}
