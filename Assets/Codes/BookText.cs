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
            left = 1;
            right = 2;
            num = 0;
            numLeft.text = "Page " + left;
            numRight.text = "Page " + right;

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            Time.timeScale = 1f;
        }

        public void NextPage()
        {
            num += 1;
            left += 2;
            right += 2;
            numLeft.text = "Page " + left;
            numRight.text = "Page " + right;

            Debug.Log (num);

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            if (right == 34)
            {
                buttonRight.interactable = false;
            }

            if (left > 1)
            {
                buttonLeft.interactable = true;
            }
        }

        public void PreviousPage()
        {
            num -= 1;
            left -= 2;
            right -= 2;
            numLeft.text = "Page " + left;
            numRight.text = "Page " + right;

            rightText.text = localizedRecipeRight[num].GetLocalizedString();
            leftText.text = localizedRecipeLeft[num].GetLocalizedString();

            if (left == 1)
            {
                buttonLeft.interactable = false;
            }

            if (right < 34)
            {
                buttonRight.interactable = true;
            }
        }
    }
}
