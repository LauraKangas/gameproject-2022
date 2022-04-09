using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FusilliProject
{
    public class BookText : MonoBehaviour
    {

        public TMP_Text buttonText;
        public TMP_Text recipe;
        public TMP_Text ingredients;
        public int num;

        public Button next;
        public Button previous;
        
        void Start()
        {
        
            num = 1;
            buttonText.text = "Page " + num;
            
            
        }

        // Update is called once per frame
        void Update()
        {

            
        
        }

        public void NewText()
        {
            
                    
                    num += 1;
                    buttonText.text = "Page " + num;

                   
            switch(num) 

                {
                  case 1:
                    ingredients.text = "first page";
                    recipe.text = "first page";
                    previous.enabled = false;
                    break;

                  case 2:
                   
                    ingredients.text = "Salaatti \n\nAinekset\n\nTomaatti\nKurkku";
                    recipe.text = "Pilko tomaatit\nPilko kurkku";
                    previous.enabled = true;
                    break;

                    case 3:
                    ingredients.text = "Uunifetapasta \n\nAinekset\n\nPasta\nKirsikkatomaatit\nFetajuusto\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset uunivuoassa\nKeitä pasta n. 15 min";
                     previous.enabled = true;
                    break;

                    case 4:
                    ingredients.text = "Tomaattikeitto \n\nAinekset\n\nTomaatti\nLiemikuutio\nSipuli\nOliviöljy";
                    recipe.text = "Sekoita kaikki ainekset\nSekoita tehosekoittimessa";
                    next.enabled = false;
                    previous.enabled = true;
                    break;

                    default:
                    // code block
                    break;

                }

        }

        public void PreviousText()
        {
            
                    
                    num -= 1;
                    buttonText.text = "Page " + num;
                    

                   
            switch(num) 

                {
                  case 1:
                    ingredients.text = "first page";
                    recipe.text = "first page";
                    previous.enabled = false;
                    next.enabled = true;
                    break;

                  case 2:
                   
                    ingredients.text = "Salaatti \n\nAinekset\n\nTomaatti\nKurkku";
                    recipe.text = "Pilko tomaatit\nPilko kurkku";
                    next.enabled = true;
                    previous.enabled = true;
                    break;

                    case 3:
                    ingredients.text = "Uunifetapasta \n\nAinekset\n\nPasta\nKirsikkatomaatit\nFetajuusto\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset uunivuoassa\nKeitä pasta n. 15 min";
                     next.enabled = true;
                     previous.enabled = true;
                    break;

                    case 4:
                    ingredients.text = "Tomaattikeitto \n\nAinekset\n\nTomaatti\nLiemikuutio\nSipuli\nOliviöljy";
                    recipe.text = "Sekoita kaikki ainekset\nSekoita tehosekoittimessa";
                    next.enabled = false;
                    previous.enabled = true;
                    break;

                    default:
                    // code block
                    break;

                }

        }



        public void pageFour()
        {
            
                   
                    num = 4;
                    
                    buttonText.text = "Page " + num;
                    
                     ingredients.text = "Tomaattikeitto \n\nAinekset\n\nTomaatti\nLiemikuutio\nSipuli\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset\nSekoita tehosekoittimessa";
                       
                         
        
        }

       
    }
}
