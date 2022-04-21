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

        public TMP_Text win, lose;

        [SerializeField]
        private GameObject scoreboard, reminder, next;

        

        

        private GameObject spawnedObject;

        
        public bool reminderSpawned;
        // Start is called before the first frame update
        void Start()
        {

            gameTime = startTime;
            timer.text = "Time: " + startTime;
            
            
            reminderSpawned = false;
            scoreboard.SetActive(false);

            
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

                

                }

             else  if (gameTime <= endTime){

                  Debug.Log("Time has run out!");

                 

                     scoreboard.SetActive(true);
                     Time.timeScale = 0f;

                   
                   totalScore.text = "Pisteet: " + ScoreController.textScore;

                   if (ScoreController.textScore < 5){

                    win.enabled = false;
                   lose.enabled = true;
                   next.SetActive(false);
               

                }  

                if (ScoreController.textScore >= 5){

                   lose.enabled = false;
                   win.enabled = true;
                   next.SetActive(true);
               

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
