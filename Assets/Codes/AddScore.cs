using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FusilliProject
{
    public class AddScore : MonoBehaviour
    {
        public TMP_Text scoreText;
        public TMP_Text highscoreText;

        private int scoreNum;
        private int highscore;

        [SerializeField]
        private int lvlNum;
        public int nextScene;

        [SerializeField]
        private LocalizedString localizedScore;

        
        // Start is called before the first frame update
        void Start()
        {
           scoreNum = 0;
           highscore = PlayerPrefs.GetInt(("highscore" + lvlNum), scoreNum);

           scoreText.text = localizedScore.GetLocalizedString() + ": " + scoreNum;
           Debug.Log("Starting score: " + scoreNum);
           highscoreText.text = "Highscore: " + highscore;

           
           
        }

        // Update is called once per frame
        void Update()
        {

        

        }

        private void OnEnable()
        {

            LocalizationSettings.SelectedLocaleChanged += OnLocalizationChanged;

        }

         private void OnDisable()
        {

            LocalizationSettings.SelectedLocaleChanged -= OnLocalizationChanged;

        }

        private void OnLocalizationChanged(Locale obj)
		{
			scoreText.text = localizedScore.GetLocalizedString() + ": " + scoreNum;
		}

        public void AddPoint(int num)
		{

            

			scoreNum += num;
            scoreText.text = localizedScore.GetLocalizedString() + ": " + scoreNum;
            Debug.Log("Current score: " + scoreNum);

            if (highscore < scoreNum)
			{

               
					    PlayerPrefs.SetInt("highscore" + lvlNum, scoreNum);
					    highscoreText.text = "Highscore: " + highscore;
                        Debug.Log("Highscore: " + highscore);

                        highscore = PlayerPrefs.GetInt(("highscore" + lvlNum), scoreNum);
                        
				}

                ScoreController.textScore = scoreNum;

            if (scoreNum >= 5) {

                    nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                    Debug.Log(nextScene);

                if (nextScene > PlayerPrefs.GetInt("lvl")) {

                    PlayerPrefs.SetInt("lvl", nextScene);

                }

                }
            
                
                
		}
    }
}
