using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FusilliProject
{
    public class RecipeBook : MonoBehaviour
    {
         [SerializeField]
        private GameObject button, button2, page_left;

         public TMP_Text recipe, ingredients, instructions, page1, page2;

        
        // Start is called before the first frame update
        void Start()
        {
            button.SetActive(false);
            button2.SetActive(false);
            instructions.enabled = false;
            recipe.enabled = false;
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
        instructions.enabled = false;
        recipe.enabled = false;
        page1.enabled = false;
        page2.enabled = false;
    }

    public void endAnimation()
    {
        
        button.SetActive(true);
        button2.SetActive(true);
        instructions.enabled = true;
        recipe.enabled = true;
        page1.enabled = true;
        page2.enabled = true;
        page_left.SetActive(false);
    }

    

    public void WaitAnimaitonEnds()
    {
        
        button.SetActive(true);
        button2.SetActive(false);
        instructions.enabled = true;
        recipe.enabled = true;
        page1.enabled = true;
        page2.enabled = true;
    }

  }
}
