using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class IngredientSpawner : MonoBehaviour, IPointerDownHandler
    {

        [SerializeField]
        private GameObject ingredient;

        private void spawn()
        {
            Instantiate(ingredient, transform.position, transform.rotation);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            spawn();
        }
    }
}