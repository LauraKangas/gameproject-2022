using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class Order : MonoBehaviour
    {
        public List<Ingredient> ingredients;

        // Voidaan määrittää etukäteen tai laskea aineksista
        public int points;

        public GameObject meal;
    }
}
