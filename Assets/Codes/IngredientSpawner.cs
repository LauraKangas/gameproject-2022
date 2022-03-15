using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class IngredientSpawner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        [SerializeField]
        private GameObject ingredientPrefab;
        private GameObject ingredient;
        private TomatoController ingredientScript;


        private void spawn()
        {
            ingredient = Instantiate(ingredientPrefab, transform.position, transform.rotation);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            spawn();
            ingredientScript = ingredient.GetComponent<TomatoController>();
            ingredientScript.OnPointerDown(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ingredientScript.OnPointerUp(eventData);
        }
    }
}