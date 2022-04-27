using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class Tutorial : MonoBehaviour
    {

        [SerializeField]
        private GameObject[] tutorial;

        private int num, imageNum;

        [SerializeField]
        public Button leftButton, rightButton;
        // Start is called before the first frame update
        void Start()
        {
            num = 0;
            tutorial[num].SetActive(true);
            leftButton.interactable = false;

        }

        // Update is called once per frame
        void Update()
        {
        
        }


    public void RightButton()
    {
        
        num+= 1;
        Debug.Log(num);

        for (int i = 0; i < tutorial.Length; i++) {

                if (i == num) {

                    tutorial[i].SetActive(true);

                }

                else {

                    tutorial[i].SetActive(false);

                } 
            }

            if (num == 11) {

                rightButton.interactable = false;

            }

            if (num > 0) {

                leftButton.interactable = true;

            }
     
            
    }

    public void LeftButton()
    {
        
        num-=1;
        Debug.Log(num);

        for (int i = 0; i < tutorial.Length; i++) {

                if (i == num) {

                    tutorial[i].SetActive(true);

                }

                else {

                    tutorial[i].SetActive(false);

                } 
            }

            if (num == 0) {

             leftButton.interactable = false;

            }

            if (num < 12) {

                rightButton.interactable = true;

            }
        }
    }
}
