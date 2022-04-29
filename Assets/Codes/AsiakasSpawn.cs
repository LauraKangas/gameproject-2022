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

		[SerializeField]
		private float spawnTime;
        
		[SerializeField]
		private float destroyTime;
		
		[SerializeField]
		private GameObject prefab, prefab1, prefab2;
		int randomSpawn;

		private float timer;
        private float timerDestroy;

		private State state = State.WaitingForSpawn;

		private GameObject spawnedObject;

		[SerializeField]
		private GameObject pauseHandler;

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

				if (spawnedObject == null)
			{
					    
                        ChangeState();
                        
						
					
				}
                break;
                }
			}

            private void ChangeState()
		{
			
			state = state == State.WaitingForDestroy
				? State.WaitingForSpawn
				: State.WaitingForDestroy;

			
			
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
			randomSpawn = Random.Range(1,7);

			switch(randomSpawn){
				case 1:
			spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
			break;

			case 2:
			spawnedObject = Instantiate(prefab1, transform.position, transform.rotation);
			break;

			case 3:
			spawnedObject = Instantiate(prefab2, transform.position, transform.rotation);
			break;

			case 4:
			spawnedObject = Instantiate(prefab, transform.position, transform.rotation);
			break;

			case 5:
			spawnedObject = Instantiate(prefab1, transform.position, transform.rotation);
			break;

			case 6:
			spawnedObject = Instantiate(prefab2, transform.position, transform.rotation);
			break;

			}

			spawnedObject.GetComponent<Draggable>().pauseHandler = this.pauseHandler.GetComponent<PauseGame>();
		}
	}

    }
