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
        // Start is called before the first frame update
        void Start()
        {

            gameTime = startTime;
            timer.text = "Time: " + startTime;
        
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

             else  {

                

                }  
        
        }
    }
}
