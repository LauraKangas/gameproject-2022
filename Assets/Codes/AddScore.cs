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
           highscore = 0;
           scoreText.text = "Score: " + scoreNum;
           Debug.Log("Starting score: " + scoreNum);

            PlayerPrefs.GetInt("highscore", scoreNum);
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

               highscore = scoreNum;
					    PlayerPrefs.SetInt("highscore", highscore);
					    highscoreText.text = "Highscore: " + highscore;
                        Debug.Log("Highscore: " + highscore);
				}
		}
    }
}
