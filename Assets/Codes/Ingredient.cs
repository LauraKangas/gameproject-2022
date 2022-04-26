using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    [System.Serializable]
    public class Ingredient
    {
        public enum ingredientType
        {
            Tomato,
            Onion,
            Garlic,
            Carrot,
            Salt,
            Manna,
            Berries,
            Honey,
            Milk,
            Potato,
            Pike,
            Egg,
            Pepper,
            Chicken,
            Rosemary,
            Pear,
            Turnip,
            Beet,
            Parsnip,
            Celeriac,
            Herring,
            Sugar,
            Berryjuice,
            Cabbage,
            Harkis,
            Pork,
            Oats,
            Apple,
            Barley
        }

        public ingredientType type;
        public int cookingState;
        public bool isCooked;
        public bool isBoiled;
        public bool isBurned;
        public bool isOvenCooked;
        public bool isFried;
    }
}
