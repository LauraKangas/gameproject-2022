using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FusilliProject
{
    public class BookText : MonoBehaviour
    {

        public TMP_Text buttonText;
        public int num;
        
        void Start()
        {
        
            num = 1;
            buttonText.text = "Page " + num;
            

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void NewText()
        {
            
                    
                    num += 1;
                    buttonText.text = "Page " + num;
                    

                    
        
        }
    }
}
