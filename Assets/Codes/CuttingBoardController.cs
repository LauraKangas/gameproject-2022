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
        private IngredientController ingredientController;

        void Start()
        {
            hasIngredient = false;
        }

        void Update()
        {
            if(ingredientController != null)
            {
                if(!ingredientController.isDragged)
                {
                    ingredientController.transform.position = this.transform.position;
                    hasIngredient = true;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            Debug.Log("enter");
            ingredientController = col.gameObject.GetComponent<IngredientController>();
            ingredientController.onBoard = true;
        }

        private void OnTriggerExit2D(Collider2D col) {
            Debug.Log("exit");
            ingredientController.onBoard = false;
            ingredientController = null;
            hasIngredient = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(hasIngredient)
            {
                ingredientController.chop();
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
    }
}
