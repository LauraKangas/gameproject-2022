using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FusilliProject
{
   public class LevelSelectionScore : MonoBehaviour
    {
        public TMP_Text hs;

        public int HS;

        public int num;
        // Start is called before the first frame update
        void Start()
        {
            
            hs.text = "Highscore: " + PlayerPrefs.GetInt(("highscore" + num), HS);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
