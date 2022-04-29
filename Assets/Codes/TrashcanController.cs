using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class TrashcanController : MonoBehaviour
    {
        private GameObject draggedTrash;

        public GameObject scoreCounter;

        private void Update()
        {
            if (draggedTrash != null)
            {
                if (!draggedTrash.GetComponent<Draggable>().isDragged)
                {
                    scoreCounter.GetComponent<AddScore>().AddPoint(-1);
                    draggedTrash.GetComponent<Draggable>().DestroyIngredient();
                }
            }
        }

        // Kuuntelija, kun jokin objekti tulee
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            if (col.tag == "Ingredient")
            {
                draggedTrash = col.gameObject;
            }
        }

        // Kuuntelija, kun jokin objekti poistuu
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            if (col.tag == "Ingredient")
            {
                draggedTrash = null;
            }
        }
    }
}
