using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class CuttingBoardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool hasIngredient;

        [SerializeField]
        private GameObject ingredient;

        void Start()
        {
            hasIngredient = false;
        }

        void Update()
        {
            if(ingredient != null)
            {
                if(!ingredient.GetComponent<TomatoController>().isDragged)
                {
                    ingredient.GetComponent<TomatoController>().setTransform(this.transform.position);
                    hasIngredient = true;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            Debug.Log("enter");
            ingredient = col.gameObject;
            ingredient.GetComponent<TomatoController>().onBoard = true;
        }

        private void OnTriggerExit2D(Collider2D col) {
            Debug.Log("exit");
            ingredient.GetComponent<TomatoController>().onBoard = false;
            ingredient = null;
            hasIngredient = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(hasIngredient)
            {
                ingredient.GetComponent<TomatoController>().chop();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}
