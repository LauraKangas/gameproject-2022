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
        public Button leftArrow, rightArrow;

        // Start is called before the first frame update
        void Start()
        {
            // Määrää tutoriaalin tekstin ja kuvan
            num = 0;

            // Asettaa tutoriaalin tekstin ja kuvan num arvon perusteella
            tutorial[num].SetActive(true);

            // Vasemmanpuoleinen näppäin ei toimi
            leftArrow.interactable = false;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void RightButton()
        {
            // Määrää uuden tekstin ja kuvan kun painaa tutoriaalin oikeanpuolista näppäintä
            num += 1;
            Debug.Log (num);

            for (int i = 0; i < tutorial.Length; i++)
            {
                // Tutoriaalin teksti ja kuva aktivoidaan jos niiden arvo on yhtä suuri kuin num arvo
                if (i == num)
                {
                    tutorial[i].SetActive(true); // Tutoriaalin teksti ja kuva aktivoidaan
                }
                else
                {
                    tutorial[i].SetActive(false); // Tutoriaalin teksti ja kuva piilotetaan
                }
            }

            // Jos sivunumero on 11 oikeanpuoleinen näppäin ei toimi 
            if (num == 11)
            {
                rightArrow.interactable = false;
            }

            // Jos sivunumero on isompi kuin 0 vasemmanpuoleinen näppäin toimii 
            if (num > 0)
            {
                leftArrow.interactable = true;
            }
        }

        public void LeftButton()
        {
            // Määrää uuden tekstin ja kuvan kun painaa tutoriaalin vasemmanpuolista näppäintä
            num -= 1;
            Debug.Log (num);

            for (int i = 0; i < tutorial.Length; i++)
            {
                // Tutoriaalin teksti ja kuva aktivoidaan jos niiden arvo on yhtä suuri kuin num arvo
                if (i == num)
                {
                    tutorial[i].SetActive(true); // Tutoriaalin teksti ja kuva aktivoidaan
                }
                else
                {
                    tutorial[i].SetActive(false); // Tutoriaalin teksti ja kuva piilotetaan
                }
            }

            // Jos sivunumero on 0 vasemmanpuoleinen näppäin ei toimi
            if (num == 0)
            {
                leftArrow.interactable = false;
            }

            // Jos sivunumero on pienempi kuin 11 oikeanpuoleinen näppäin toimii 
            if (num < 11)
            {
                rightArrow.interactable = true;
            }
        }
    }
}
