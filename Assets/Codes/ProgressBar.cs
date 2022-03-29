using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class ProgressBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;
        public Image fill;

        public void SetTreshold(float treshold)
        {
            slider.maxValue = treshold;
            slider.value = 0;

            fill.color = gradient.Evaluate(1f);
        }
        
        public void SetProgress(float passedTime)
        {
            slider.value = passedTime;

            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
