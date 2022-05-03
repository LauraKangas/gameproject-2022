using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class CountdownController : MonoBehaviour
    {

        [SerializeField]
        private GameObject timer;

        public void CountdownDone()
        {
            timer.GetComponent<Timer>().startedTimer = true;
            Destroy(this.gameObject);
        }
    }
}
