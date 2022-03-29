using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class Plate : MonoBehaviour
    {
        [System.Serializable]
        public class Recipe
        {
            public List<Ingredient> recipeIngredients;
        }

        // Lautasella olevan aterian kokonaispistemäärä
        private int score;

        private List<IngredientController> ingredients;

        [SerializeField]
        public Recipe recipe;
    }
}
