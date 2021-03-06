using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FusilliProject
{
    public class AddScore : MonoBehaviour
    {
        public TMP_Text scoreText;

        public TMP_Text highscoreText;

        private int scoreNum;

        private int highscore;

        [SerializeField]
        private int lvlNum; // Asetetaan tason numeron tasovalikon high score pisteytystä varten

        [SerializeField]
        private LocalizedString localizedScore;

        // Start is called before the first frame update
        void Start()
        {
            // Asettaa tason pisteet nollaksi tason alussa
            scoreNum = 0;

            // Asettaa tason high score tason alussa
            highscore = PlayerPrefs.GetInt(("highscore" + lvlNum), scoreNum);

            scoreText.text = localizedScore.GetLocalizedString() + ":" + scoreNum;
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
            scoreText.text = localizedScore.GetLocalizedString() + ":" + scoreNum;
        }

        public void AddPoint(int num)
        {
            // Lisää pisteitä
            scoreNum += num;
            scoreText.text = localizedScore.GetLocalizedString() + ":" + scoreNum;
            Debug.Log("Current score: " + scoreNum);

            // Asettaa uuden high scoren jos entinen high score on 
            // pienempi kuin uusi pistemäärä
            if (highscore < scoreNum)
            {
                PlayerPrefs.SetInt("highscore" + lvlNum, scoreNum);
                highscoreText.text = "Highscore: " + highscore;
                Debug.Log("Highscore: " + highscore);

                highscore = PlayerPrefs.GetInt(("highscore" + lvlNum), scoreNum);
            }

            ScoreController.score = scoreNum;

        }
    }
}
