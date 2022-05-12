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

            // Inventoryn avaaminen estetään
            inventory.SetActive(false);

            // Inventoryn näppäin ei toimi
            button.interactable = false;

            // Pysäyttää pelin
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            isPaused = false;
            
            // Inventoryn avaaminen asetetaan
            inventory.SetActive(true);

            // Inventoryn näppäin aktivoidaan
            button.interactable = true;

            // Käynnistää pelin
            Time.timeScale = 1f;
        }
    }
}
