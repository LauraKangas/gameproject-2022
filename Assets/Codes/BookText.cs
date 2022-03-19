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
        
        void Start()
        {
        
            num = 1;
            buttonText.text = "Page " + num;
            ingredients.text = "Makaronilaatikko \n\nAinekset\n\nJauheliha\nMakaronit";
            recipe.text = "Paista jauheliha\nKeitä makaronit";

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void NewText()
        {
            
                    
                    num += 1;
                    buttonText.text = "Page " + num;

                   
                        if(num >= 2){
                            
                    
                    ingredients.text = "Salaatti \n\nAinekset\n\nTomaatti\nKurkku";
                    recipe.text = "Pilko tomaatit\nPilko kurkku";

                        }

                         if(num >= 3){

                     ingredients.text = "Uunifetapasta \n\nAinekset\n\nPasta\nKirsikkatomaatit\nFetajuusto\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset uunivuoassa\nKeitä pasta n. 15 min";

                        }

                        if(num >= 4){

                     ingredients.text = "Tomaattikeitto \n\nAinekset\n\nTomaatti\nLiemikuutio\nSipuli\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset\nSekoita tehosekoittimessa";

                        }
                         
        
        }

       
    }
}
