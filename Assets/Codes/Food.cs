using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class Food : MonoBehaviour, IPointerClickHandler
    {
        public PlateController plate;

        public void OnPointerClick(PointerEventData eventData)
        {
            plate.DeliverOrder();
        }
    }
}
