using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace FusilliProject
{
    public class BookText : MonoBehaviour
    {
        public TMP_Text numLeft, numRight;

        private int left, right, num;

        public Button buttonRight, buttonLeft;

        public TMP_Text rightText, leftText;

        [SerializeField]
        private LocalizedString[] localizedRecipeRight;

        [SerializeField]
        private LocalizedString[] localizedRecipeLeft;

        void Start()
        {
            BookEnter();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnEnable()
        {
            LocalizationSettings.SelectedLocaleChanged += OnLocalizationChanged;
        }

        private void OnDisable()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocalizationChanged;
        }

        private void OnLocalizationChanged(Locale obj)
        {
            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();
        }

        public void BookEnter()
        {
            // Asettaa kirjan vasemmanpuoleisen sivunumeron kun kirja avataan
            left = 1;

            // Asettaa kirjan oikeanpuoleisen sivunumeron kun kirja avataan
            right = 2;

            // Määrää kirjan tekstit kun kirja avataan
            num = 0;
            numLeft.text = left.ToString();
            numRight.text = right.ToString();

            // Oikeanpuoleinen näppäin on ainoa toimiva kun kirja avataan
            buttonRight.interactable = true;

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            Time.timeScale = 1f;
        }

        public void NextPage()
        {
            // Määrää uuden tekstin kun sivu vaihtuu
            num += 1;

            // Asettaa uuden sivunumeron kun sivu vaihtuu seuraavalle sivulle
            // lisäämällä 2
            left += 2;

            // Asettaa uuden sivunumeron kun sivu vaihtuu seuraavalle sivulle
            // lisäämällä 2
            right += 2;
            numLeft.text = left.ToString();
            numRight.text = right.ToString();

            Debug.Log (num);

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            // Jos sivunumero on 42 oikeanpuoleinen näppäin ei toimi 
            if (right == 42)
            {
                buttonRight.interactable = false;
            }

            // Jos sivunumero on isompi kuin 1 vasemmanpuoleinen näppäin toimii 
            if (left > 1)
            {
                buttonLeft.interactable = true;
            }
        }

        public void PreviousPage()
        {
            // Määrää uuden tekstin kun sivu vaihtuu
            num -= 1;

            // Asettaa uuden sivunumeron kun sivu vaihtuu edelliselle sivulle
            // vähentämällä 2
            left -= 2;

            // Asettaa uuden sivunumeron kun sivu vaihtuu edelliselle sivulle
            // vähentämällä 2
            right -= 2;

            numLeft.text = left.ToString();
            numRight.text = right.ToString();

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            // Jos sivunumero on 1 vasemmanpuoleinen näppäin ei toimi 
            if (left == 1)
            {
                buttonLeft.interactable = false;
            }

            // Jos sivunumero on pienempi kuin 42 oikeanpuoleinen näppäin toimii 
            if (right < 42)
            {
                buttonRight.interactable = true;
            }
        }
    }
}
