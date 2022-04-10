using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/**
Skripti leikkuulaudan funktionaalisuuden määrittelylle

Määrittää leikkuulaudan tilan hallinnnan, laudalla olevien ainesten keskityksen ja poistamisen laudalta,
sekä ainesten pilkkomisen.


@author Johan Lummeranta 
@version 1.00, 22.3.2022

22.3.2022 Johan Lummeranta
Lisätty toiminnallisuus ylimääräisten ainesten poistamiselle laudalta

*/

namespace FusilliProject
{
    public class CuttingBoardController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // Onko laudalla leikeltävä aines
        private bool hasIngredient;

        // Piste josta ylimääräinen aines on vedetty laudalle, aineksen poistamista varten
        private Vector3 secondIngredientEnterPos;

        [SerializeField]
        // Ensisijaisen aineksen Controller
        private GameObject ingredient;

        [SerializeField]
        // Ylimääräisen aineksen Controller
        private GameObject secondIngredient;

        void Start()
        {
            hasIngredient = false;
        }

        void Update()
        {
            /*
            Jos laudalla ei ole ensisijaista ainesta,
            mutta on ylimääräinen aines, otetaan ylimääräinen aines ensisijaiseksi
            */
            if (ingredient == null)
            {
                if (secondIngredient != null)
                {
                    ingredient = secondIngredient;
                    secondIngredient = null;
                }
            }

            // Jos laudalla on ensisjainen aines
            if (ingredient != null)
            {
                // Jos ensisijainen aines on raahattavana, päivitetään ettei se ole leikeltävänä
                if (ingredient.GetComponent<Draggable>().isDragged && hasIngredient)
                {
                    hasIngredient = false;
                }

                // Jos ensisijaista ainesta ei olla liikuttamassa, eikä se ole leikeltävänä otetaan se leikeltäväksi 
                if (!ingredient.GetComponent<Draggable>().isDragged && !hasIngredient)
                {
                    ingredient.transform.position = this.transform.position;
                    hasIngredient = true;
                }
                // Jos laudalla on myös ylimääräinen aines, jota pelaaja ei ole liikuttamassa, työnnetään sitä ulos laudalta
                else if (secondIngredient != null)
                {
                    if (!secondIngredient.GetComponent<Draggable>().isDragged)
                    {
                        Vector2 move = (secondIngredientEnterPos - secondIngredient.transform.position).normalized * Time.deltaTime * 10;
                        secondIngredient.transform.Translate(move);
                    }
                }
            }
        }

        // Kuuntelija, kun jokin objekti tulee laudalle
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            if (col.tag == "Ingredient")
            {
                // Jos laudalla ei ole ensisijaista ainesta, asetetaan laudalle vedetty aines ensisijaiseksi ainekseksi
                if (ingredient == null)
                {
                    ingredient = col.gameObject;
                    // Merkitään ainekselle sen olevan laudalla
                    ingredient.GetComponent<IngredientController>().onBoard = true;
                }
                // Jos laudalla on jo ensisijainen aines, asetetaan laudalle vedetty aines ylimääräiseksi
                else
                {
                    secondIngredient = col.gameObject;
                    secondIngredientEnterPos = secondIngredient.transform.position;
                    // Merkitään ainekselle sen olevan laudalla
                    secondIngredient.GetComponent<IngredientController>().onBoard = true;
                }
            }
        }

        // Kuuntelija, kun jokin objekti poistuu laudalta
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            if (col.tag == "Ingredient")
            {
                // Jos poistuva aines on ensisijainen aines, merkitään sen poistuminen ainekselle itselleen ja poistetaan viittaus laudalta
                if (col.gameObject.Equals(ingredient))
                {
                    ingredient.GetComponent<IngredientController>().onBoard = false;
                    ingredient = null;
                    hasIngredient = false;
                }

                // Jos poistuva aines on on toissijainen aines, merkitään sen poistuminen ainekselle itselleen ja poistetaan viittaus laudalta
                else if (col.gameObject.GetComponent<IngredientController>().Equals(secondIngredient))
                {
                    secondIngredient.GetComponent<IngredientController>().onBoard = false;
                    secondIngredient = null;
                }
            }
        }

        // Kuuntelija tarkkailemaan painellaanko lautaa, leikkelyä varten
        public void OnPointerDown(PointerEventData eventData)
        {
            // Jos laudalla on leikeltävä aines, kutsutaan sen pilkkomismetodia
            if (hasIngredient)
            {
                ingredient.GetComponent<IngredientController>().chop();
            }
        }

        // !!Saatetaan vaatia OnPointerDown-metodin toiminnallisuuden vuoksi, poistettava vain jos kyseinen metodi on korvattu tai toimii ilman tätä!!
        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}
