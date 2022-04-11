using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public bool isDragged;

        public Vector3 startPos;

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
            startPos = this.transform.position;
            this.isDragged = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.isDragged = false;
        }

        public void returnToStart()
        {
            this.transform.position = this.startPos;
            // Vector2 move = (startPos - this.transform.position).normalized * Time.deltaTime * 10;
            // this.transform.Translate(move);
        }
    }
}
