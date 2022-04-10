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

        public enum ToolType
        {
            pan,
            kettle,
            oven
        }

        public ToolType toolType;

        [SerializeField]
        // Ainesten Controllerit
        private List<GameObject> ingredients;

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
            this.timeToCooked = 5;
            this.timeToBurned = 8;
            this.progressBar.SetTreshold(timeToBurned);

        }

        void Update()
        {

            // Jos esineellä on valmistuva aines
            if (ingredients.Count > 0)
            {

                // Jos viimeisintä ainesta ei olla liikuttamassa, eikä se ole valmistumassa otetaan se valmistettavaksi 
                if (!ingredients[ingredients.Count - 1].GetComponent<Draggable>().isDragged && !ingredients[ingredients.Count - 1].GetComponent<IngredientController>().beingCooked)
                {
                    ingredients[ingredients.Count - 1].transform.position = this.progressBar.transform.position;
                    ingredients[ingredients.Count - 1].GetComponent<IngredientController>().beingCooked = true;
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
                    foreach (GameObject ingredient in ingredients)
                    {
                        ingredient.GetComponent<IngredientController>().isBurned = true;
                    }
                }
                else if (cookingTimer >= timeToCooked)
                {
                    foreach (GameObject ingredient in ingredients)
                    {
                        switch (toolType)
                        {
                            case ToolType.pan:
                            ingredient.GetComponent<IngredientController>().isCooked = true;
                            break;

                            case ToolType.kettle:
                            ingredient.GetComponent<IngredientController>().isBoiled = true;
                            break;

                            default:
                            ingredient.GetComponent<IngredientController>().isCooked = true;
                            break;
                        }
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
            if (col.tag == "Ingredient")
            {
                // Lisätään aineksen Controller esineellä olevien ainesten controller listaan
                ingredients.Add(col.gameObject);
            }
        }

        // Kuuntelija, kun jokin objekti poistuu laudalta
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");
            if (col.tag == "Ingredient")
            {
                // Poistetaan pois vedetyn aineksen Controller listasta
                ingredients.Remove(col.gameObject);
                col.gameObject.GetComponent<IngredientController>().beingCooked = false;
                if (ingredients.Count < 1) {
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
