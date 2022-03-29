using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FusilliProject
{
    public class CookingController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // Onko esineessä aines valmistumassa
        private bool hasIngredient;

        [SerializeField]
        // Ainesten Controllerit
        private List<IngredientController> ingredientControllers;

        [SerializeField]
        // Kauan ainekset ovat olleet valmistumassa
        private float cookingTimer;

        [SerializeField]
        // Kauan aineksien paisto kokonaisuudessaan kestää
        private float timeToCooked;

        [SerializeField]
        // Kauan ainesten poltto paistamisen jälkeen kokonaisuudessaan kestää
        private float timeToBurned;

        [SerializeField]
        // Valmistuksen ja palamisen edistymismittari
        private ProgressBar progressBar;

        [SerializeField]
        private Animator animator;

        void Start()
        {
            this.hasIngredient = false;
            this.cookingTimer = 0;
            this.timeToCooked = 20;
            this.timeToBurned = 30;
            this.progressBar.SetTreshold(timeToBurned);

        }

        void Update()
        {

            // Jos esineellä on valmistuva aines
            if (ingredientControllers.Count > 0)
            {

                // Jos viimeisintä ainesta ei olla liikuttamassa, eikä se ole valmistumassa otetaan se valmistettavaksi 
                if (!ingredientControllers[ingredientControllers.Count - 1].isDragged && !ingredientControllers[ingredientControllers.Count - 1].beingCooked)
                {
                    ingredientControllers[ingredientControllers.Count - 1].transform.position = this.transform.position;
                    ingredientControllers[ingredientControllers.Count - 1].beingCooked = true;
                    this.hasIngredient = true;
                    if (animator != null)
                    {
                        animator.SetBool("hasIngredient", this.hasIngredient);
                    }
                }

                if (hasIngredient)
                {
                    cookingTimer += Time.deltaTime;
                }

                if (cookingTimer >= timeToBurned)
                {
                    foreach (IngredientController ingredient in ingredientControllers)
                    {
                        ingredient.isBurned = true;
                    }
                }
                else if (cookingTimer >= timeToCooked)
                {
                    foreach (IngredientController ingredient in ingredientControllers)
                    {
                        ingredient.isCooked = true;
                    }

                }
            }
            // Jos aineksia ei ole valmistumassa, nollataan valmistusajastin
            else {
                cookingTimer = 0;
            }

            progressBar.SetProgress(cookingTimer);
        }

        // Kuuntelija, kun jokin objekti tulee laudalle
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            // !!Ei tarkistusta onko tuleva objekti aines, tarkistus lisättävä!!
            if (true)
            {
                // Lisätään aineksen Controller esineellä olevien ainesten controller listaan
                ingredientControllers.Add(col.gameObject.GetComponent<IngredientController>());
            }
        }

        // Kuuntelija, kun jokin objekti poistuu laudalta
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            // !!Ei tarkistusta onko poistuva objekti aines, tarkistus lisättävä!!
            if (true)
            {
                // Poistetaan pois vedetyn aineksen Controller listasta
                ingredientControllers.Remove(col.gameObject.GetComponent<IngredientController>());
                col.gameObject.GetComponent<IngredientController>().beingCooked = false;
                if (ingredientControllers.Count < 1) {
                    this.hasIngredient = false;
                    if (animator != null)
                    {
                        animator.SetBool("hasIngredient", this.hasIngredient);
                    }
                }
            }
        }

        // Kuuntelija tarkkailemaan painellaanko esinettä
        public void OnPointerDown(PointerEventData eventData)
        {
        }

        // !!Saatetaan vaatia OnPointerDown-metodin toiminnallisuuden vuoksi, poistettava vain jos kyseinen metodi on korvattu tai toimii ilman tätä!!
        public void OnPointerUp(PointerEventData eventData)
        {

        }
    }
}
