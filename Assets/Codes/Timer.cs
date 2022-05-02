using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

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
            gameTime = startTime;

            //timer.text = "Time: " + startTime;
            Time.timeScale = 1f;

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
            if (gameTime > endTime && startedTimer)
            {
                float minutes = Mathf.FloorToInt(gameTime / 60);
                float seconds = Mathf.FloorToInt(gameTime % 60);

                gameTime -= Time.deltaTime;

                timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (gameTime <= endTime)
            {
                Debug.Log("Time has run out!");

                scoreboard.SetActive(true);
                Time.timeScale = 0f;

                totalScore.text = localizedPoints.GetLocalizedString() + ": " + ScoreController.score;

                if (ScoreController.score < 50)
                {
                    win.enabled = false;
                    lose.enabled = true;
                    next.SetActive(false);

                    if (!isPlaying)
                    {
                        if (lose_audio != null)
                        {
                            lose_audio.Play();
                            isPlaying = true;
                        }
                    }
                }

                if (ScoreController.score >= 50)
                {
                    lose.enabled = false;
                    win.enabled = true;
                    next.SetActive(true);

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

            if (gameTime <= 120)
            {
                timer.color = new Color(255, 0, 0, 255);

                if (!reminder)
                {
                    if (time_audio != null)
                    {
                        time_audio.Play();
                        reminder = true;
                    }
                }
            }

            if (gameTime <= 115)
            {
                timer.color = new Color(255, 255, 255, 255);

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
