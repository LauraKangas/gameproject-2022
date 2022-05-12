using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FusilliProject
{
    public class RecipeBook : MonoBehaviour
    {
        [SerializeField]
        private GameObject rightButton, leftButton, turnPage;

        public TMP_Text rightPage, leftPage, leftNum, rightNum;

        // Start is called before the first frame update
        // Kun kirja avautuu, kirjan näppäimet ja tekstit ovat piilotettuna
        void Start()
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
            leftPage.enabled = false;
            rightPage.enabled = false;
            leftNum.enabled = false;
            rightNum.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
        }

        // Kun kirjan sivua vaihtaa, kirjan näppäimet, sivunumerot ja tekstit piilotetaan
        public void StartAnimation()
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
            leftPage.enabled = false;
            rightPage.enabled = false;
            leftNum.enabled = false;
            rightNum.enabled = false;
        }

        // Kun kirjan sivu on vaihtunut, sivu piilotetaan ja kirjan näppäimet,
        // sivunumerot sekä tekstit aktivoidaan
        public void EndAnimation()
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
            leftPage.enabled = true;
            rightPage.enabled = true;
            leftNum.enabled = true;
            rightNum.enabled = true;
            turnPage.SetActive(false);
        }

        // Kun kirja on avattu, kirjan oikeanpuolinen näppäin, sivunumerot ja tekstit aktivoidaan
        public void RecipeBookEnd()
        {
            rightButton.SetActive(true);
            leftButton.SetActive(false);
            leftPage.enabled = true;
            rightPage.enabled = true;
            leftNum.enabled = true;
            rightNum.enabled = true;
        }
    }
}
