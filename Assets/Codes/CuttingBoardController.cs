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
        private IngredientController ingredientController;

        [SerializeField]
        // Ylimääräisen aineksen Controller
        private IngredientController secondIngredientController;

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
            if (ingredientController == null)
            {
                if (secondIngredientController != null)
                {
                    ingredientController = secondIngredientController;
                    secondIngredientController = null;
                }
            }

            // Jos laudalla on ensisjainen aines
            if (ingredientController != null)
            {
                // Jos ensisijainen aines on raahattavana, päivitetään ettei se ole leikeltävänä
                if (ingredientController.isDragged && hasIngredient)
                {
                    hasIngredient = false;
                }

                // Jos ensisijaista ainesta ei olla liikuttamassa, eikä se ole leikeltävänä otetaan se leikeltäväksi 
                if (!ingredientController.isDragged && !hasIngredient)
                {
                    ingredientController.transform.position = this.transform.position;
                    hasIngredient = true;
                }
                // Jos laudalla on myös ylimääräinen aines, jota pelaaja ei ole liikuttamassa, työnnetään sitä ulos laudalta
                else if (secondIngredientController != null)
                {
                    if (!secondIngredientController.isDragged)
                    {
                        // !!Jostain syystä liikkuu ajoittain hitaammin, syy epäselvä!!
                        Vector2 move = (secondIngredientEnterPos - secondIngredientController.transform.position).normalized * Time.deltaTime * 2;
                        secondIngredientController.transform.Translate(move);
                    }
                }
            }
        }

        // Kuuntelija, kun jokin objekti tulee laudalle
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            // !!Ei tarkistusta onko tuleva objekti aines, tarkistus lisättävä!!
            if (true)
            {
                // Jos laudalla ei ole ensisijaista ainesta, asetetaan laudalle vedetty aines ensisijaiseksi ainekseksi
                if (ingredientController == null)
                {
                    ingredientController = col.gameObject.GetComponent<IngredientController>();
                    // Merkitään ainekselle sen olevan laudalla
                    ingredientController.onBoard = true;
                }
                // Jos laudalla on jo ensisijainen aines, asetetaan laudalle vedetty aines ylimääräiseksi
                else
                {
                    secondIngredientController = col.gameObject.GetComponent<IngredientController>();
                    secondIngredientEnterPos = secondIngredientController.transform.position;
                    // Merkitään ainekselle sen olevan laudalla
                    secondIngredientController.onBoard = true;
                }
            }
        }

        // Kuuntelija, kun jokin objekti poistuu laudalta
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            // !!Ei tarkistusta onko poistuva objekti aines, tarkistus lisättävä!!
            if (true)
            {
                // Jos poistuva aines on ensisijainen aines, merkitään sen poistuminen ainekselle itselleen ja poistetaan viittaus laudalta
                if (col.gameObject.GetComponent<IngredientController>().Equals(ingredientController))
                {
                    ingredientController.onBoard = false;
                    ingredientController = null;
                    hasIngredient = false;
                }

                // Jos poistuva aines on on toissijainen aines, merkitään sen poistuminen ainekselle itselleen ja poistetaan viittaus laudalta
                else if (col.gameObject.GetComponent<IngredientController>().Equals(secondIngredientController))
                {
                    secondIngredientController.onBoard = false;
                    secondIngredientController = null;
                }
            }
        }

        // Kuuntelija tarkkailemaan painellaanko lautaa, leikkelyä varten
        public void OnPointerDown(PointerEventData eventData)
        {
            // Jos laudalla on leikeltävä aines, kutsutaan sen pilkkomismetodia
            if (hasIngredient)
            {
                ingredientController.chop();
            }
        }

        // !!Saatetaan vaatia OnPointerDown-metodin toiminnallisuuden vuoksi, poistettava vain jos kyseinen metodi on korvattu tai toimii ilman tätä!!
        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}
