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
                if(!ingredient.GetComponent<IngredientController>().isDragged)
                {
                    ingredient.GetComponent<IngredientController>().setTransform(this.transform.position);
                    hasIngredient = true;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            Debug.Log("enter");
            ingredient = col.gameObject;
            ingredient.GetComponent<IngredientController>().onBoard = true;
        }

        private void OnTriggerExit2D(Collider2D col) {
            Debug.Log("exit");
            ingredient.GetComponent<IngredientController>().onBoard = false;
            ingredient = null;
            hasIngredient = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(hasIngredient)
            {
                ingredient.GetComponent<IngredientController>().chop();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}
