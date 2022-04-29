using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FusilliProject
{
    public class PlateController : MonoBehaviour, IPointerClickHandler
    {
        // Lista lautaselle vedetyistä aineksista
        public List<GameObject> ingredients = new List<GameObject>();

        // Viittaus lautaselle koottavaan tilaukseen,
        // tilauslapun paikka ikkunassa asettaa tämän
        public GameObject order;

        // Lautasella olevan aterian kokonaispistemäärä laskettuna aineksista verrattuna tilaukseen
        private int score;

        [SerializeField]
        // Viittaukset aineksille varattuihin slotteihin. Valmistellaan käsiteltävän reseptin mukaan
        private List<GameObject> ingredientSlots;

        [SerializeField]
        // Viittaus tilaukselle varattuun slotti-olioon.
        private GameObject orderSlot;

        private GameObject meal;

        public GameObject scoreCounter;

        private bool mealComplete = false;

        public bool ingredientSlotsHidden = true;

        [SerializeField]
        private AudioSource audio_plate, audio_meal;

        private void Update()
        {

            if (order != null)
            {
                if (ingredients != null)
                {
                    foreach (GameObject ingredient in ingredients)
                    {
                        if (!ingredient.GetComponent<Draggable>().isDragged && !ingredient.GetComponent<IngredientController>().onPlate && !mealComplete)
                        {
                            ingredient.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            ingredient.GetComponent<IngredientController>().onPlate = true;
                            ingredient.GetComponent<Draggable>().fixedInPlace = true;
                            ingredient.GetComponent<Draggable>().draggable = false;
                            int flaws = RateIngredient(ingredient.GetComponent<IngredientController>());
                            ingredient.GetComponent<IngredientController>().points -= flaws;
                            int ingCount = IngredientToSlot(ingredient.GetComponent<IngredientController>(), flaws);

                            if (audio_plate != null)
                            {
                                audio_plate.Play();

                            }

                            if (ingCount >= order.GetComponent<Order>().ingredients.Count)
                            {
                                CompleteMeal();
                            }
                        }
                    }
                }
            }
            else if (order == null && !ingredientSlotsHidden)
            {
                hideIngredientSlots();
                destroyIngredients();
            }
        }

        // Kuuntelija, kun jokin objekti tulee
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("enter");
            if ((col.tag == "Ingredient" || col.tag == "Spice") && col.gameObject.GetComponent<Draggable>().isDragged)
            {
                ingredients.Add(col.gameObject);
            }
        }

        // Kuuntelija, kun jokin objekti poistuu
        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("exit");

            if (col.tag == "Ingredient" || col.tag == "Spice")
            {
                if (!col.gameObject.GetComponent<IngredientController>().onPlate)
                {
                    ingredients.Remove(col.gameObject);
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            DeliverOrder();


            if (audio_meal != null)
            {
                audio_meal.Play();
            }
        }

        public void DeliverOrder()
        {
            if (meal != null)
            {
                score = 0;
                foreach (GameObject ingredient in ingredients)
                {
                    score += ingredient.GetComponent<IngredientController>().points;
                }
                scoreCounter.GetComponent<AddScore>().AddPoint(score);

                destroyIngredients();

                mealComplete = false;
                Destroy(order);
                Destroy(meal);
            }
        }

        private int RateIngredient(IngredientController ingredient)
        {
            bool sameIngredientFound = false;
            int flaws = 0;

            for (int i = 0; i < ingredients.Count - 1; i++)
            {
                if (ingredients[i].GetComponent<IngredientController>().type == ingredient.type)
                {
                    flaws += 4;
                    sameIngredientFound = true;
                }
            }

            if (sameIngredientFound)
            {
                return flaws;
            }

            foreach (Ingredient orderIngredient in order.GetComponent<Order>().ingredients)
            {
                if (orderIngredient.type == ingredient.type)
                {
                    if (orderIngredient.cookingState != ingredient.chopState)
                    {
                        flaws++;
                    }
                    if (orderIngredient.isBoiled != ingredient.isBoiled)
                    {
                        flaws++;
                    }
                    if (orderIngredient.isOvenCooked != ingredient.isOvenCooked)
                    {
                        flaws++;
                    }
                    if (orderIngredient.isFried != ingredient.isFried)
                    {
                        flaws++;
                    }
                    if (orderIngredient.isCooked != ingredient.isCooked)
                    {
                        flaws += 2;
                    }
                    if (ingredient.isBurned)
                    {
                        flaws += 3;
                    }

                    return flaws;
                }
            }

            // Aines ei edes kuulu reseptiin
            flaws = 6;
            return flaws;
        }

        private int IngredientToSlot(IngredientController ingredient, int flaws)
        {
            int i = 0;
            foreach (GameObject ingredientSlot in ingredientSlots)
            {
                i++;
                if (ingredientSlot.transform.GetChild(1).gameObject.GetComponent<Image>().sprite == null)
                {
                    ingredientSlot.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = ingredient.ingredientStages[0];
                    ingredientSlot.transform.GetChild(1).gameObject.GetComponent<Image>().preserveAspect = true;
                    ingredientSlot.transform.GetChild(1).gameObject.SetActive(true);
                    ingredient.transform.position = ingredientSlot.transform.position;

                    if (flaws <= 0)
                    {
                        ingredientSlot.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(107, 238, 37, 170);
                    }
                    else if (flaws >= 1 && flaws <= 5)
                    {
                        ingredientSlot.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(214, 238, 37, 170);
                    }
                    else if (flaws >= 6)
                    {
                        ingredientSlot.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(238, 51, 37, 170);
                    }

                    return i;
                }
            }
            return 4;
        }

        private void CompleteMeal()
        {
            meal = Instantiate(order.GetComponent<Order>().meal, (transform.position + new Vector3(0.07f, 0.08f, 0)), transform.rotation);
            meal.GetComponent<Food>().plate = this;
            mealComplete = true;
            hideIngredientSlots();
        }

        public void prepareIngredientSlots()
        {
            for (int i = 0; i < order.GetComponent<Order>().ingredients.Count; i++)
            {
                ingredientSlots[i].transform.GetChild(0).gameObject.SetActive(true);
            }

            ingredientSlotsHidden = false;
        }

        private void hideIngredientSlots()
        {
            foreach (GameObject ingredientSlot in ingredientSlots)
            {
                ingredientSlot.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
                ingredientSlot.transform.GetChild(0).gameObject.SetActive(false);
                ingredientSlot.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = null;
                ingredientSlot.transform.GetChild(1).gameObject.SetActive(false);
            }

            ingredientSlotsHidden = true;
        }

        private void destroyIngredients()
        {
            for (int i = ingredients.Count - 1; i >= 0; i--)
            {
                if (ingredients[i].tag == "Ingredient")
                {
                    ingredients[i].GetComponent<Draggable>().DestroyIngredient();
                }
                else
                {
                    Destroy(ingredients[i]);
                }
                ingredients.RemoveAt(i);
            }
        }
    }
}
