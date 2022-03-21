using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace FusilliProject
{
    public class IngredientController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private int chopState;
        public bool onBoard;

        public bool isDragged;

        [SerializeField]
        public Sprite[] ingredientStages;

        //private Animator chopAnimator;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            //this.chopAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            this.isDragged = true;
            this.onBoard = false;
            this.chopState = 0;
            this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            this.spriteRenderer.sprite = ingredientStages[0];

        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.isDragged = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            this.isDragged = false;
        }

        private void OnTouchPosition(InputAction.CallbackContext context)
        {
            
            if(!this.isDragged)
            {
                return;
            }

            Vector3 touchPosition = context.ReadValue<Vector2>();

            Vector3 coordinate = Camera.main.ScreenToWorldPoint(touchPosition);
            this.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
        }

        public void setTransform(Vector3 newPos)
        {
            this.transform.position = newPos;
        }

        public void chop()
        {
            if(this.chopState < 3)
            {
                this.chopState++;
            }
            this.spriteRenderer.sprite = this.ingredientStages[this.chopState];
        }
    }
}
