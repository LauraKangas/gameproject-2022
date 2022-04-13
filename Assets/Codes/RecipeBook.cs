using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FusilliProject
{
    public class RecipeBook : MonoBehaviour
    {
         [SerializeField]
        private GameObject button, button2;

         public TMP_Text recipe, ingredients, instructions, page1, page2;

        
        // Start is called before the first frame update
        void Start()
        {
            button.SetActive(false);
            button2.SetActive(false);
            recipe.enabled = false;
            ingredients.enabled = false;
            instructions.enabled = false;
            page1.enabled = false;
            page2.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
         
        }

       
    public void startAnimation()
    {
        
        button.SetActive(false);
            button2.SetActive(false);
            recipe.enabled = false;
            ingredients.enabled = false;
            instructions.enabled = false;
            page1.enabled = false;
            page2.enabled = false;
    }

    public void WaitAnimaitonEnds()
    {
        
        button.SetActive(true);
        button2.SetActive(true);
        recipe.enabled = true;
        ingredients.enabled = true;
        instructions.enabled = true;
        page1.enabled = true;
        page2.enabled = true;
    }

  }
}
