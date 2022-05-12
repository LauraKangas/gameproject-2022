using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FusilliProject
{
    public class Timer : MonoBehaviour
    {
        private float gameTime; // Pelin ajastin

        private float startTime = 301; // Asettaa aloitusajan

        private float endTime = 0; // Asettaa lopetusajan

        public int nextScene;

        public TMP_Text timer;

        public TMP_Text totalScore;

        public TMP_Text win, lose;

        [SerializeField]
        private GameObject scoreboard, next;

        [SerializeField]
        private AudioSource audio_bg, win_audio, lose_audio, time_audio;

        private bool isPlaying;

        private bool reminder;

        public bool startedTimer = false;

        [SerializeField]
        private LocalizedString localizedPoints;

        // Start is called before the first frame update
        void Start()
        {
            // Asettaa pelin ajastimelle aloitusajan
            gameTime = startTime;

            //timer.text = "Time: " + startTime;
            Time.timeScale = 1f;

            // Piilottaa scoreboardin
            scoreboard.SetActive(false);

            if (audio_bg != null)
            {
                audio_bg.Play();
            }

            isPlaying = false;
        }

        // Update is called once per frame
        void Update()
        {
            // Pelin ajastimen aika laskee jos sen aika on isompi kuin 0
            // ja pelin countdown poistetaan
            if (gameTime > endTime && startedTimer)
            {
                float minutes = Mathf.FloorToInt(gameTime / 60);
                float seconds = Mathf.FloorToInt(gameTime % 60);

                gameTime -= Time.deltaTime;

                timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            // Kun pelin ajastimen arvo on 0 ajastin pysähtyy 
            else if (gameTime <= endTime)
            {
                Debug.Log("Time has run out!");

                // Scoreboard aktivoidaan
                scoreboard.SetActive(true);

                // Pysäyttää pelissä kaikki ajasta riippuvaiset ominaisuudet, 
                // kuten ruoan kypsentäminen ja tilauslappujen ajastimet
                Time.timeScale = 0f;

                totalScore.text = localizedPoints.GetLocalizedString() + ":" + ScoreController.score;

                // Jos pelin pisteet ovat vähemmän kuin 50 peli on hävitty
                if (ScoreController.score < 50)
                {
                    win.enabled = false; // Voitto teksti piilossa
                    lose.enabled = true; // Häviö teksti aktivoidaan
                    next.SetActive(false); // Näppäin seuraavalle tasolle piilotetaan

                    if (!isPlaying)
                    {
                        if (lose_audio != null)
                        {
                            lose_audio.Play();
                            isPlaying = true;
                        }
                    }
                }

                // Jos pelin pisteet on suurempi kuin 50 peli on voitettu
                if (ScoreController.score >= 50)
                {
                    lose.enabled = false; // Häviö teksti piilossa
                    win.enabled = true; // Voitto teksti aktivoidaan
                    next.SetActive(true); // Näppäin seuraavalle tasolle aktivoidaan

                    // Asettaa nextScene arvoksi nykyisen scenen arvon + 1
                    nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                    Debug.Log (nextScene);

                    // Jos nextScene arvo on isompi kuin tasovalikon nykyinen taso arvo
                    // uusi taso arvo tallennetaan
                    if (nextScene > PlayerPrefs.GetInt("lvl"))
                    {
                        PlayerPrefs.SetInt("lvl", nextScene);
                    }

                    if (!isPlaying)
                    {
                        if (win_audio != null)
                        {
                            win_audio.Play();
                            isPlaying = true;
                        }
                    }
                }
            }

            // Kun pelin ajastin osuu 120 sekuntiin ajastimen numerot muuttuu punaiseksi
            if (gameTime <= 120)
            {
                timer.color = new Color(255, 0, 0, 255); // Numerot muutetaan punaiseksi

                if (!reminder)
                {
                    if (time_audio != null)
                    {
                        time_audio.Play(); 
                        reminder = true;
                    }
                }
            }

            // Kun pelin ajastin osuu 115 sekuntiin ajastimen numerot palaa valkoiseksi
            if (gameTime <= 115)
            {
                timer.color = new Color(255, 255, 255, 255); // Numerot muutetaan valkoiseksi

                if (reminder)
                {
                    if (time_audio != null)
                    {
                        time_audio.Stop();
                        reminder = false;
                    }
                }
            }
        }
    }
}
