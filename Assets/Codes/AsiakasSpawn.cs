using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class AsiakasSpawn : MonoBehaviour
    {
   

        public enum State
		{
			WaitingForSpawn,
			WaitingForDestroy
		}

		[SerializeField, Tooltip("The time after which an object is spawned (in seconds)")]
		private float spawnTime;
        
        
[SerializeField, Tooltip("The time after which an object is spawned (in seconds)")]
		private float destroyTime;
		

		[SerializeField, Tooltip("A reference to the prefab we want to create copies from")]
		private GameObject prefab;

		private float timer;
        private float timerDestroy;

		private State state = State.WaitingForSpawn;

		private GameObject spawnedObject;

		void Start()
		{
			timer = spawnTime;
            timerDestroy = destroyTime;
		}

		void Update()
		{
			switch (state)
				{

                    case State.WaitingForSpawn:
            if (timer > 0)
			{

                timer -= Time.deltaTime;
            if (timer <= 0)
			{
					    Spawn();
                        ChangeState();
						Debug.Log("not Destroyed");
					
				}
						
					
				}

                break;

                case State.WaitingForDestroy:

                 if (timerDestroy > 0)
			{

                timerDestroy -= Time.deltaTime;
            if (timerDestroy <= 0)
			{
					    DoDestroy();
                        ChangeState();
                        
						Debug.Log("Destroyed");
					
				}
						
					
				}
                break;
                }
			}

            private void ChangeState()
		{
			// Vastaa if-else -rakennetta ja muuttujaan sijoittamista
			state = state == State.WaitingForDestroy
				? State.WaitingForSpawn
				: State.WaitingForDestroy;

			
			// if (state == State.WaitingForDestroy)
			// {
			// 	state = State.WaitingForSpawn;
			// }
			// else
			// {
			// 	state = State.WaitingForDestroy;
			// }

			// Alustetaan timer uudelleen
			timer = spawnTime;
            timerDestroy = destroyTime;
		}
		

		

		private void DoDestroy()
		{
			Destroy(spawnedObject);
			spawnedObject = null;
		}

		
		

		private void Spawn()
		{
			spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
		}
	}

    }
