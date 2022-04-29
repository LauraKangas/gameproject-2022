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

        private GameObject spawnedOrder;

        

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            if (spawnedOrder == null && !GetComponent<Draggable>().isDragged && !GetComponent<Draggable>().pauseHandler.isPaused)
            {
                
                spawnedOrder = Instantiate(orderLarge, new Vector2(-0.2f, 0.2f), transform.rotation);
                Debug.Log(name + " is larger");

            }

            
        }




    }
}
