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

        public void StartAnimation()
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
            leftPage.enabled = false;
            rightPage.enabled = false;
            leftNum.enabled = false;
            rightNum.enabled = false;
        }

        public void EndAnimation()
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
            leftPage.enabled = true;
            rightPage.enabled = true;
            leftNum.enabled = true;
            rightNum.enabled = true;
            //turnPage.SetActive(false);
        }

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
