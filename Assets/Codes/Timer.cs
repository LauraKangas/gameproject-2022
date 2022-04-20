using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FusilliProject
{


   
    public class Timer : MonoBehaviour
    {

        private float gameTime;

        private float startTime = 301;

        private float endTime = 0;

        public TMP_Text timer;

        public TMP_Text totalScore;

        [SerializeField]
        private GameObject scoreboard, reminder;

        private GameObject spawnedObject;

        public bool scoreSpawned;
        public bool reminderSpawned;
        // Start is called before the first frame update
        void Start()
        {

            gameTime = startTime;
            timer.text = "Time: " + startTime;
            totalScore.enabled = false;
            reminderSpawned = false;
        }

        // Update is called once per frame
        void Update()
        {


            if (gameTime > endTime)
			{

                float minutes = Mathf.FloorToInt(gameTime/60);
                float seconds = Mathf.FloorToInt(gameTime%60);

                gameTime -= Time.deltaTime;

                timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                scoreSpawned = false;

                }

             else  if (gameTime <= endTime){

                  Debug.Log("Time has run out!");

                 if (scoreSpawned == false){


                   Instantiate(scoreboard, transform.position, transform.rotation);
                   scoreSpawned = true;

                   totalScore.enabled = true;
                   totalScore.text = "Total score: " + ScoreController.textScore;


               

                }  
            } 

            if (gameTime <= 120)
			{
                if (!reminderSpawned){


                spawnedObject = Instantiate(reminder, new Vector2 (7.2f, -3.8f), transform.rotation);
                reminderSpawned = true;

                }

                
            }

            if (gameTime <= 115){

                if (reminderSpawned){

                Destroy(spawnedObject);
                reminderSpawned = false;

                }
            }
        
        }

        
    }
}
