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
        private GameObject[] prefab;

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
            Destroy (spawnedObject);
            spawnedObject = null;
        }

        private void Spawn()
        {
            randomSpawn = Random.Range(0, 6);

            spawnedObject = Instantiate(prefab[randomSpawn], transform.position, transform.rotation);

			Debug.Log(randomSpawn);

            spawnedObject.GetComponent<Draggable>().pauseHandler = this.pauseHandler.GetComponent<PauseGame>();
        }
    }
}
