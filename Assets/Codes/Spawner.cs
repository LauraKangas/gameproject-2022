using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FusilliProject
{
    public class Spawner : MonoBehaviour
    {
        public enum State
		{
			WaitingForSpawn,
			WaitingForDestroy
		}

		[SerializeField, Tooltip("The time after which an object is spawned (in seconds)")]
		private float spawnTime;

		

		[SerializeField, Tooltip("A reference to the prefab we want to create copies from")]
		private GameObject prefab;

        private GameObject plate;

        public int num;

		
		void Start()
		{

                 Spawn();

		}

		void Update()
		{

            
                    
		}
				
			

		private void Spawn()
		{
			Instantiate(prefab, transform.position, transform.rotation);
		}
    }
  }