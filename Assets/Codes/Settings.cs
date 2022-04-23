using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace FusilliProject
{
    public class Settings : MonoBehaviour
    {

        [SerializeField]
        private AudioControl musicControl;

        [SerializeField]
        private AudioControl sfxControl;

        [SerializeField]
        private string musicVolumeName;

        [SerializeField]
        private string sfxVolumeName;

        [SerializeField]
        private AudioMixer mixer;

        // Start is called before the first frame update
        private void Start()
        {
           musicControl.Setup(mixer, musicVolumeName);
           sfxControl.Setup(mixer, sfxVolumeName);

        }

        // Update is called once per frame
        void Update()
        {
            musicControl.Save();
            sfxControl.Save();
        
        }
    }
}
