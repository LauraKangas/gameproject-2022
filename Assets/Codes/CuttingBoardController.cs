using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class CuttingBoardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool hasIngredient;
        private Vector3 secondIngredientEnterPos;

        [SerializeField]
        private IngredientController ingredientController;
        private IngredientController secondIngredientController;

        void Start()
        {
            hasIngredient = false;
        }

        void Update()
        {
            if(ingredientController == null)
            {
                if(secondIngredientController != null)
                {
                    ingredientController = secondIngredientController;
                    secondIngredientController = null;
                }
            }

            if(ingredientController != null)
            {
                if(!ingredientController.isDragged && !hasIngredient)
                {
                    ingredientController.transform.position = this.transform.position;
                    hasIngredient = true;
                }
                else if(secondIngredientController != null)
                {
                    if(!secondIngredientController.isDragged)
                    {
                        Vector2 move = secondIngredientEnterPos * Time.deltaTime;
                        secondIngredientController.transform.Translate(move);
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D col) {
            Debug.Log("enter");
            if(!hasIngredient) {
                ingredientController = col.gameObject.GetComponent<IngredientController>();
                ingredientController.onBoard = true;
            }
            else
            {
                secondIngredientController = col.gameObject.GetComponent<IngredientController>();
                secondIngredientEnterPos = secondIngredientController.transform.position;
                secondIngredientController.onBoard = true;
            }
        }

        private void OnTriggerExit2D(Collider2D col) {
            Debug.Log("exit");
            if(col.gameObject.GetComponent<IngredientController>().Equals(ingredientController))
            {
                ingredientController.onBoard = false;
                ingredientController = null;
                hasIngredient = false;
            }
            else if(col.gameObject.GetComponent<IngredientController>().Equals(secondIngredientController))
            {
                secondIngredientController.onBoard = false;
                secondIngredientController = null;
            }
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
