using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class OrderOpen : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField]
        private GameObject orderLarge;

        

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if (!GetComponent<Draggable>().isDragged)
            {
                

                Instantiate(orderLarge, new Vector2(-0.2f, 0.2f), transform.rotation);
                Debug.Log(name + " is larger");

                

                
            }

            
        }




    }
}
