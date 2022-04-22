using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool isDragged;

        public bool fixedInPlace = true;

        public int speed = 10;

        public Vector3 startPos;

        public int tableSlot;

        public GameObject tableSurface;

        public bool draggable = true;

        void Start()
        {
            if (tag == "Order")
            {
                startPos = this.transform.position;
            }
        }

        void Update()
        {
            if (!this.fixedInPlace && !this.isDragged)
            {
                returnToStart();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Jos aines ei ole raahattavana, ohitetaan metodi
            if (this.isDragged)
            {
                // Luetaan kosketus piste ruudulta
                Vector3 touchPosition = eventData.position;

                // Muutetaan kosketuspiste pelimaailman koordinaatiksi
                Vector3 coordinate = Camera.main.ScreenToWorldPoint(touchPosition);

                // Siirretään aines kosketettuun koordinaattiin
                this.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // if (inPlace)
            // {
            //     startPos = this.transform.position;
            // }
            if (draggable)
            {
                fixedInPlace = false;
                this.isDragged = true;
            }

            AudioSource audio = GetComponent<AudioSource>();

                if (audio != null)
				{
					audio.Play();
					
				} 
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.isDragged = false;
        }

        public void returnToStart()
        {
            // this.transform.position = this.startPos;
            Vector2 path = (startPos - this.transform.position);

            Vector2 move = path.normalized * Time.deltaTime * speed;
            float distanceToStart = path.magnitude;
            if (distanceToStart > move.magnitude)
            {
                this.transform.Translate(move);
            }
            else
            {
                this.transform.position = startPos;
                this.fixedInPlace = true;
            }
        }

        public void DestroyIngredient()
        {
            tableSurface.GetComponent<SurfaceController>().availabilities[tableSlot] = true;
            Destroy(this.gameObject);
        }

        public void setTableSlot(GameObject tableSurface)
        {
            this.tableSurface = tableSurface;
            tableSlot = this.tableSurface.GetComponent<SurfaceController>().FindSlot(this);
        }
    }
}
