using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace FusilliProject
{
    public class AudioControl : MonoBehaviour
    {

        private AudioMixer mixer;

        private Slider slider;

        private string volumeName;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        
        }

        public void Setup(AudioMixer mixer, string volumeName)
        {
            this.mixer = mixer;
            this.volumeName = volumeName;

            if (mixer.GetFloat(volumeName, out float volume)){

                slider.value = volume;

                }
        
        }

        public void Save()
        {
            mixer.SetFloat(volumeName, slider.value);
        }
        

    }
}
