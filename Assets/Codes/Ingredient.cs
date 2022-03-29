using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    [System.Serializable]
    public class Ingredient
    {
        enum ingredientType
        {
            Tomato,
            Onion,
            Garlic
        }

        public int cookingState;
        public bool isCooked;
        public bool isBoiled;
        public bool isBurned;
    }
}
