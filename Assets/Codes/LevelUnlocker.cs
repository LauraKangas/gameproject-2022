using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class LevelUnlocker : MonoBehaviour
    {

        public Button[] lvlButtons;

        int lvl;
        // Start is called before the first frame update
        void Start()
        {

            lvl = PlayerPrefs.GetInt("lvl", 3);

            for (int i = 0; i < lvlButtons.Length; i++) {

                if (i + 3 > lvl) {

                    lvlButtons[i].interactable = false;

                }

                else {

                    lvlButtons[i].interactable = true;

                } 
            }
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
