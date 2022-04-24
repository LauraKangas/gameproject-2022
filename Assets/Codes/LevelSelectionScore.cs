using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FusilliProject
{
   public class LevelSelectionScore : MonoBehaviour
    {
        public TMP_Text hs;

        public int HS;

        public int num;

        [SerializeField]
        private LocalizedString localizedHS;
        // Start is called before the first frame update
        void Start()
        {
            
            hs.text = localizedHS.GetLocalizedString() + ": " + PlayerPrefs.GetInt(("highscore" + num), HS);
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
			hs.text = localizedHS.GetLocalizedString() + ": " + PlayerPrefs.GetInt(("highscore" + num), HS);
		}
    }
}
