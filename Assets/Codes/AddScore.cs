using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FusilliProject
{
    public class AddScore : MonoBehaviour
    {
         public TMP_Text scoreText;
          public TMP_Text highscoreText;

        private int scoreNum;
        private int highscore;

        
        // Start is called before the first frame update
        void Start()
        {
           scoreNum = 0;
           highscore = PlayerPrefs.GetInt("highscore", scoreNum);

           scoreText.text = "Score: " + scoreNum;
           Debug.Log("Starting score: " + scoreNum);
           highscoreText.text = "Highscore: " + highscore;

           
           
        }

        // Update is called once per frame
        void Update()
        {

        

        }


        public void AddPoint(int num)
		{

            

			scoreNum += num;
            scoreText.text = "Score: " + scoreNum;
            Debug.Log("Current score: " + scoreNum);

            if (highscore < scoreNum)
			{

               
					    PlayerPrefs.SetInt("highscore", scoreNum);
					    highscoreText.text = "Highscore: " + highscore;
                        Debug.Log("Highscore: " + highscore);
                        
				}

                ScoreController.textScore = scoreNum;
                
                
		}
    }
}
