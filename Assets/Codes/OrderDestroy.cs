using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class OrderDestroy : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            // Tuhoaa suurennetun tilauslapun
            Destroy (gameObject);
            Debug.Log(name + " is destroyed");
        }
    }
}
