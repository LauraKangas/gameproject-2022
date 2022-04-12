using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class PauseGame : MonoBehaviour
    {
        
        public bool isPaused;

        [SerializeField]
        private GameObject inventory;

        [SerializeField]
        public Button button;

        public void Pause()
        {
            isPaused = true;
            inventory.SetActive(false);
            button.interactable = false;
            Time.timeScale = 0f;
            
        }

        public void Resume()
        {
            Time.timeScale = 1f;
            inventory.SetActive(true);
            button.interactable = true;
            isPaused = false;
        }
    }
}
