using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FusilliProject
{
    public class LappuTimer : MonoBehaviour
    {
        [SerializeField]
        private Image timebar;

        [SerializeField]
        private float customerTime;

        private float timeLeft;

        // Start is called before the first frame update
        void Start()
        {
            // Timebar on täynnä
            timeLeft = customerTime;
        }

        // Update is called once per frame
        void Update()
        {
            // Jos jäljellä oleva aika on yli 0 aika laskee
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                // Palkin sisältö pienenee jäljellä olevan ajan mukaisesti
                timebar.fillAmount = timeLeft / customerTime;
            }
        }
    }
}
