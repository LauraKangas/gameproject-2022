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
        // Valmistuksen edistymismittari
        private ProgressBar cookingBar;

        [SerializeField]
        // Palamisen edistymismittari
        private ProgressBar burningBar;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AudioSource audio_cook;

        void Start()
        {
            this.hasIngredient = false;
            this.cookingTimer = 0;
            this.timeToCooked = 5;
            this.timeToBurned = 5;
            this.cookingBar.SetTreshold(timeToCooked);
            this.burningBar.SetTreshold(timeToBurned);

        }

        void Update()
        {

            // Jos esineellä on valmistuva aines
            if (ingredients.Count > 0)
            {

                if (ingredients[0].GetComponent<IngredientController>().chopState < 3  )
                {}
                else if (ingredients[0].GetComponent<Draggable>().isDragged && ingredients[0].GetComponent<IngredientController>().beingCooked)
                {
                    ingredients[0].GetComponent<IngredientController>().beingCooked = false;
                    ingredients[0].GetComponent<Draggable>().fixedInPlace = false;
                    this.hasIngredient = false;
                    if (animator != null)
                    {
                        animator.SetBool("hasIngredient", this.hasIngredient);

                        if (audio_cook != null)
				        {
					        audio_cook.Stop();
					
				            } 
                    }
                }
                // Jos ensimmäistä ainesta ei olla liikuttamassa, eikä se ole valmistumassa otetaan se valmistukseen
                else if (!ingredients[0].GetComponent<Draggable>().isDragged && !ingredients[0].GetComponent<IngredientController>().beingCooked)
                {
                    ingredients[0].transform.position = this.cookingBar.transform.position;
                    ingredients[0].GetComponent<IngredientController>().beingCooked = true;
                    ingredients[0].GetComponent<Draggable>().fixedInPlace = true;
                    this.hasIngredient = true;
                    if (animator != null)
                    {
                        animator.SetBool("hasIngredient", this.hasIngredient);

                        if (audio_cook != null)
				        {
					        audio_cook.Play();
					
				            } 
                    }
                }

                if (hasIngredient)
                {
                    cookingTimer += Time.deltaTime;

                    if (cookingTimer - timeToCooked >= timeToBurned)
                    {
                        ingredients[0].GetComponent<IngredientController>().isBurned = true;
                    }
                    else if (cookingTimer >= timeToCooked)
                    {

                        switch (toolType)
                        {
                            case ToolType.pan:
                                ingredients[0].GetComponent<IngredientController>().isFried = true;
                                break;

                            case ToolType.kettle:
                                ingredients[0].GetComponent<IngredientController>().isBoiled = true;
                                break;

                            case ToolType.oven:
                                ingredients[0].GetComponent<IngredientController>().isOvenCooked = true;
                                break;

                            default:
                                ingredients[0].GetComponent<IngredientController>().isCooked = true;
                                break;
                        }

                        ingredients[0].GetComponent<IngredientController>().isCooked = true;

                    }
                }

            }
            // Jos aineksia ei ole valmistumassa, nollataan valmistusajastin
            else
            {
                cookingTimer = 0;
            }

            cookingBar.SetProgress(cookingTimer);
            if (cookingTimer - timeToCooked >= 0)
            {
                burningBar.SetProgress(cookingTimer - timeToCooked);
            }
            else
            {
                burningBar.SetProgress(0);
            }
        }

        // Kuuntelija, kun jokin objekti tulee laudalle
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            if (col.tag == "Ingredient" && col.gameObject.GetComponent<Draggable>().isDragged)
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
                if (ingredients.Count < 1)
                {
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
