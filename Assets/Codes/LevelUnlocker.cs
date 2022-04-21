using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class LevelUnlocker : MonoBehaviour
    {

        public Button[] lvlButtons;

        public GameObject[] locks;

        int lvl;
        // Start is called before the first frame update
        void Start()
        {

            lvl = PlayerPrefs.GetInt("lvl", 3);

            for (int i = 0; i < lvlButtons.Length; i++) {

                if (i + 3 > lvl) {

                    lvlButtons[i].interactable = false;
                    locks[i].SetActive(true);

                }

                else {

                    lvlButtons[i].interactable = true;
                    locks[i].SetActive(false);

                } 
            }
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
