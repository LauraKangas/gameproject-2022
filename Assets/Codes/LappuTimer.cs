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
            timeLeft = customerTime;
        }

        // Update is called once per frame
        void Update()
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                timebar.fillAmount = timeLeft / customerTime;
            }
        }
    }
}
