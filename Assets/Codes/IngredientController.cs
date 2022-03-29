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
    public class IngredientController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        // Aineksen pilkkomisvaiheen seuranta, yleensä 0-3
        private int chopState;

        [SerializeField]
        // Onko aines valmistettu
        public bool isCooked;

        [SerializeField]
        // Onko aines poltettu
        public bool isBurned;

        // Onko aines leikkuulaudalla
        public bool onBoard;

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

            this.beingCooked = false;

            this.isCooked = false;

            this.isBurned = false;

            // Asetetaan aines ensimmäiseen pilkkomisvaiheensa, yleensä kokonainen
            this.chopState = 0;

            // Asetetaan viittaus aineksen SpriteRenderer-komponenttiin
            this.spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            this.spriteRenderer.sprite = ingredientStages[0];

        }

        private void Update()
        {
            if (this.isBurned && burnedSprite != null)
            {
                this.spriteRenderer.sprite = burnedSprite;
            }
            else if (this.isCooked && cookedSprite != null)
            {
                this.spriteRenderer.sprite = cookedSprite;
            }
        }

        // Kuuntelija, jos pelaaja painaa sormen ainekselle, asetetaan se raahattavaksi
        public void OnPointerDown(PointerEventData eventData)
        {
            this.isDragged = true;
        }

        // Kuuntelija, jos pelaaja nostaa sormensa ainekselta, lopetetaan raahaus
        public void OnPointerUp(PointerEventData eventData)
        {
            this.isDragged = false;
        }

        // Kuuntelija tarkkailemaan mihin pelaaja vetää sormeaan kun aines on raahattavana
        private void OnTouchPosition(InputAction.CallbackContext context)
        {
            // Jos aines ei ole raahattavana, ohitetaan metodi
            if (this.isDragged)
            {
                // Luetaan kosketus piste ruudulta
                Vector3 touchPosition = context.ReadValue<Vector2>();

                // Muutetaan kosketuspiste pelimaailman koordinaatiksi
                Vector3 coordinate = Camera.main.ScreenToWorldPoint(touchPosition);

                // Siirretään aines kosketettuun koordinaattiin
                this.transform.position = new Vector3(coordinate.x, coordinate.y, 0);
            }
        }

        // !!Transformin setteri, väliaikainen ratkaisu, joka ei taida enää olla missään käytössä!!
        public void setTransform(Vector3 newPos)
        {
            this.transform.position = newPos;
        }

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
