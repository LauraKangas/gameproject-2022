using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class OrderSlotController : MonoBehaviour
    {
        // Käsittelyssä oleva tilaus
        public GameObject order;
        public Draggable orderDragger;
        public GameObject extraOrder;
        public Draggable extraOrderDragger;
        public GameObject plate;
        private PlateController plateController;

        private bool hasOrder = false;

        private void Start()
        {
            plateController = plate.GetComponent<PlateController>();
        }

        private void Update()
        {

            if (order != null)
            {
                if (!orderDragger.isDragged && !hasOrder)
                {
                    order.transform.position = this.transform.position;
                    plateController.order = this.order;
                    plateController.prepareIngredientSlots();
                }
                if (extraOrder != null)
                {
                    if (!extraOrderDragger.isDragged)
                    {
                        extraOrderDragger.returnToStart();
                    }
                }
            }
        }

        // Kuuntelija, kun jokin objekti tulee
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            if (col.tag == "Order")
            {
                if (order == null)
                {
                    order = col.gameObject;
                    orderDragger = order.GetComponent<Draggable>();
                }
                else
                {
                    extraOrder = col.gameObject;
                    extraOrderDragger = extraOrder.GetComponent<Draggable>();
                }
            }
        }

        // Kuuntelija, kun jokin objekti poistuu
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            if (col.tag == "Order")
            {
                if (col.gameObject.Equals(order))
                {
                    order = null;
                    orderDragger = null;
                    plateController.order = null;
                }
                else if (col.gameObject.Equals(extraOrder))
                {
                    extraOrder = null;
                    extraOrderDragger = null;
                }
            }
        }
    }
}
