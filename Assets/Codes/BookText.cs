using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FusilliProject
{
    public class BookText : MonoBehaviour
    {

        public TMP_Text pageNum;
        public TMP_Text pageNum2;
        
        public int num, num2, num3;

        public Button next;
        public Button previous;

        public TMP_Text texts, texts2;
        

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
			texts.text = localizedRecipeRight[num3].GetLocalizedString();
            texts2.text = localizedRecipeLeft[num3].GetLocalizedString();
      
		}

        public void BookEnter()
        {
            
            num = 1;
            num2 = 2;
            num3 = 0;
            pageNum.text = "Page " + num;
            pageNum2.text = "Page " + num2;

            texts.text = localizedRecipeRight[num3].GetLocalizedString();
            texts2.text = localizedRecipeLeft[num3].GetLocalizedString();

            

        }

        public void NewText()
        {
            
            num3 += 1;
            num += 2;
            num2 += 2;
            pageNum.text = "Page " + num;
            pageNum2.text = "Page " + num2;

            Debug.Log(num3);

            texts.text = localizedRecipeRight[num3].GetLocalizedString();
            texts2.text = localizedRecipeLeft[num3].GetLocalizedString();

            if (num2 == 34) {

                next.interactable = false;
            }

            if (num > 1){

                previous.interactable = true;
            }

        }

        public void PreviousText()
        {
            
                    
            num3 -= 1;
            num -= 2;
            num2 -= 2;
            pageNum.text = "Page " + num;
            pageNum2.text = "Page " + num2;
        
            texts.text = localizedRecipeRight[num3].GetLocalizedString();
            texts2.text = localizedRecipeLeft[num3].GetLocalizedString();
            
            if (num == 1) {

                    previous.interactable = false;
            }

            if (num2 < 34){

                next.interactable = true;
            }
        }
       
    }
}
