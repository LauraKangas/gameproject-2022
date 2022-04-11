using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/**
Skripti ainesten funktionaalisuuden määrittelylle

Määrittää aineksen raahauksen ja pilkonnan.


@author Johan Lummeranta 
@version 2.00, 22.3.2022


15.3.2022 Johan Lummeranta
Muutettu TomtatoControllerista yleisempään muotoon kaikille aineksille

*/

namespace FusilliProject
{
    public class IngredientController : MonoBehaviour, IPointerDownHandler
    {

        public Ingredient.ingredientType type;

        [SerializeField]
        // Aineksen pilkkomisvaiheen seuranta, yleensä 0-3
        public int chopState;

        [SerializeField]
        // Onko aines valmistettu
        public bool isCooked;

        public bool isBoiled;

        [SerializeField]
        // Onko aines poltettu
        public bool isBurned;

        // Onko aines leikkuulaudalla
        public bool onBoard;

        public bool onPlate;

        [SerializeField]
        // Onko aines valmistumassa
        public bool beingCooked;

        // Onko aines pelaajan vedeltävänä
        public bool isDragged;

        [SerializeField]
        // Aineksen pilkkomisasteiden spritet, pidettävä oikeassa järjestyksessä
        public Sprite[] ingredientStages;

        public Sprite cookedSprite;

        public Sprite burnedSprite;

        //private Animator chopAnimator;

        // Viittaus aineksen SpriteRenderer komponenttiin
        private SpriteRenderer spriteRenderer;

        public int points;

        private void Awake()
        {
            //this.chopAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            // Asetetaan aines luodessa vedetyksi, sillä aines luodaan painamalla inventorya
            // jolloin sitä voidaan haluta välittömästi vetää
            // Muutettava jos halutaan aineksen spawnaavan muualle kuin pelaajan sormen alle
            this.isDragged = true;

            this.onBoard = false;

            this.onPlate = false;

            this.beingCooked = false;

            this.isCooked = false;

            this.isBoiled = false;

            this.isBurned = false;

            // Asetetaan aines ensimmäiseen pilkkomisvaiheensa, yleensä kokonainen
            this.chopState = 0;

            // Asetetaan viittaus aineksen SpriteRenderer-komponenttiin
            this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            this.spriteRenderer.sprite = ingredientStages[0];

        }

        private void Update()
        {
            if (this.isBurned && this.burnedSprite != null && !this.onPlate)
            {
                this.spriteRenderer.sprite = burnedSprite;
            }
            else if ((this.isCooked || this.isBoiled) && this.cookedSprite != null && !this.onPlate)
            {
                this.spriteRenderer.sprite = cookedSprite;
            }
        }

        // Kuuntelija, jos pelaaja painaa sormen ainekselle, kun se on leikkuulaudalla, leikataan ainesta
        public void OnPointerDown(PointerEventData eventData)
        {
            if(this.onBoard)
            {
                chop();
            }

            // this.isDragged = true;
        }

        // Kuuntelija, jos pelaaja nostaa sormensa ainekselta, lopetetaan raahaus
        //!! Korvattu DragHandlereillä!!
        // public void OnPointerUp(PointerEventData eventData)
        // {
        //     this.isDragged = false;
        // }

        // Kuuntelija tarkkailemaan mihin pelaaja vetää sormeaan kun aines on raahattavana
        //!! Korvattu DragHandlereillä
        // private void OnTouchPosition(InputAction.CallbackContext context)
        // {
        //     // Jos aines ei ole raahattavana, ohitetaan metodi
        //     if (this.isDragged)
        //     {
        //         // Luetaan kosketus piste ruudulta
        //         Vector3 touchPosition = context.ReadValue<Vector2>();

        //         // Muutetaan kosketuspiste pelimaailman koordinaatiksi
        //         Vector3 coordinate = Camera.main.ScreenToWorldPoint(touchPosition);

        //         // Siirretään aines kosketettuun koordinaattiin
        //         this.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
        //     }
        // }

        // public void OnDrag(PointerEventData eventData)
        // {
        //     // Jos aines ei ole raahattavana, ohitetaan metodi
        //     if (this.isDragged)
        //     {
        //         // Luetaan kosketus piste ruudulta
        //         Vector3 touchPosition = eventData.position;

        //         // Muutetaan kosketuspiste pelimaailman koordinaatiksi
        //         Vector3 coordinate = Camera.main.ScreenToWorldPoint(touchPosition);

        //         // Siirretään aines kosketettuun koordinaattiin
        //         this.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
        //     }
        // }

        // public void OnBeginDrag(PointerEventData eventData)
        // {
        //     this.isDragged = true;
        // }

        // public void OnEndDrag(PointerEventData eventData)
        // {
        //     this.isDragged = false;      
        // }

        // !!Transformin setteri, väliaikainen ratkaisu, joka ei taida enää olla missään käytössä!!
        // public void setTransform(Vector3 newPos)
        // {
        //     this.transform.position = newPos;
        // }

        // Pilkkomismetodi, leikkuulaudan kutsuttavaksi
        public void chop()
        {
            // Jos aines ei ole jo viimeisessä pilkkomisasteessaan, nostetaan pilkkomisastetta
            if (this.chopState < 3)
            {
                this.chopState++;
                // Muutetaan aineksen ulkonäkö vastaamaan uutta pilkkomisastetta
                this.spriteRenderer.sprite = this.ingredientStages[this.chopState];
            }
        }
    }
}
