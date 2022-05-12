using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FusilliProject
{
    public class LevelSelectionScore : MonoBehaviour
    {
        public TMP_Text hs;

        public int HS;

        public int numLevel; // Asettaa menu tauluille taso arvot high score pisteytystä varten

        [SerializeField]
        private LocalizedString localizedHS;

        // Start is called before the first frame update
        void Start()
        {
            // Näyttää tasojen high scoret
            hs.text = localizedHS.GetLocalizedString() + ": " + PlayerPrefs.GetInt(("highscore" + numLevel), HS);
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
            hs.text = localizedHS.GetLocalizedString() + ": " + PlayerPrefs.GetInt(("highscore" + numLevel), HS);
        }
    }
}
