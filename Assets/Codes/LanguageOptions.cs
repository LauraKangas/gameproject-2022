using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FusilliProject
{
    public class LanguageOptions : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private Locale locale;

        public void SetLocale()
        {
            LocalizationSettings.SelectedLocale = locale;

        }

        
    }
}
