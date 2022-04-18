using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FusilliProject
{
    public class BookText : MonoBehaviour
    {

        public TMP_Text pageNum;
        public TMP_Text pageNum2;
        public TMP_Text recipe;
        public TMP_Text ingredients;
        public TMP_Text instructions;
        public int num, num2;

        public Button next;
        public Button previous;

        
        
        void Start()
        {
        
            num = 1;
            num2 = 2;
            pageNum.text = "Page " + num;
            pageNum2.text = "Page " + num2;
            
            
        }

        // Update is called once per frame
        void Update()
        {

            
        
        }

        public void NewText()
        {
            
                    
                    num += 2;
                    num2 += 2;
                    pageNum.text = "Page " + num;
                    pageNum2.text = "Page " + num2;

                   
            switch(num) 

                {
                  case 1:
                    ingredients.text = "4 annosta \n\n300 g jauhoista perunaa \n200 g porkkanaa \n100 g juuriselleriä \n100 g palsternakka \n6 dl kasvislientä1 dl kermaa tai maitoa \n2 tl Valkopippuria \nSuolaa maun mukaan";
                    recipe.text = "Juuressosekeitto";
                    instructions.text = "1. Kuori perunat, porkkanat, juuriselleri ja palsternakka. Leikkaa juurekset tasakokoisiksi paloiksi. \n2. Kaada kasvisliemi kattilaan, lisää juurekset. Keitä juureksia, kunnes ne ovat pehmenneitä ja kypsiä. \n3. Kun juurekset ovat kypsiä, soseuta keitto blenderillä tai sauvasekoittimella. Ole varovainen, kuuma keitto roiskuu helposti! \n4. Kaada tarvittaessa keitto takaisin kattilaan. Lisää mausteet ja kerma, sekoita huolellisesti. Maista ja mausta lisää tarvittaessa. Jos keitto tuntuu liian paksulta, lisää runsaammin kermaa.";
                    
                    
                    break;

                  

                   case 3:
                    ingredients.text = "4 annosta \n\n200 g silakkafilettä \n800g kiinteitä perunoita (n. 6-8 perunaa) \n1 sipuli \n1dl kermaa/maitoa \n3dl kalalientä \nloraus öljyä \n1 tl maustepippuria, lisää maun mukaan \nsuolaa maun mukaan \nHienonnettua tilliä maun mukaan";
                    recipe.text = "Silakkalaatikko";
                    instructions.text = "1. Kuori perunat ja siivuta ne ohuiksi siivuiksi. Leikkaa silakkafileet paloiksi. \n2. Keitä perunaviipaleita kattilassa n. 10min. Viipaleiden ei tarvitse olla kypsiä! Valuta viipaleet ja jätä odottamaan. \n3. Leikkaa sipuli pieniksi kuutioiksi. \n4. Lorauta syvälle paistinpannulle öljyä ja lisää sipulit. Kuullota, kunnes sipuli on hiukan läpikuultavaa. \n5. Lisää pannulle perunat, kala sekä nesteet. Mausta. Peitä kannella ja hauduta kunnes kala kypsää ja perunat pehmeitä haarukalla tuikatessa. Kypsennysaika riippuu vahvasti siitä, kuinka ohuiksi perunat on leikattu.";
                    next.interactable = true;
                    
                    break;
                    
                    
                    break;

                    case 5:
                    ingredients.text = "4 annosta \n\n8dl Marja / hedelmämehua, sokeroimatonta \n1 dl valitsemiasi marjoja tai hedelmänpaloja \n1dl sokeria \n5 rlk perunajauhoa";
                    recipe.text = "Mehukiisseli";
                    instructions.text = "1. Sekoita kattilassa kaikki ainesosat sekaisin. \n2. Kuumenna miedolla lämmöllä kiisseliä sekoittaen jatkuvasti, kunnes näet ensimmäisen kuplan pulpahtavan pintaan. \n3. Kun ensimmäinen iso kupla näkyy, ota kiisseli pois lämmöltä ja anna sen jäähtyä. \n4. Tarjoile esimerkiksi sokerin tai marjojen kanssa.";
                    next.interactable = false;
                    
                    break;

                    default:
                    // code block
                    break;

                }

        }

        public void PreviousText()
        {
            
                    
                    num -= 2;
                    num2 -= 2;
                    pageNum.text = "Page " + num;
                    pageNum2.text = "Page " + num2;

                   
            switch(num) 

                {
                  case 1:
                    ingredients.text = "4 annosta \n\n300 g jauhoista perunaa \n200 g porkkanaa \n100 g juuriselleriä \n100 g palsternakka \n6 dl kasvislientä1 dl kermaa tai maitoa \n2 tl Valkopippuria \nSuolaa maun mukaan";
                    recipe.text = "Juuressosekeitto";
                    instructions.text = "1. Kuori perunat, porkkanat, juuriselleri ja palsternakka. Leikkaa juurekset tasakokoisiksi paloiksi. \n2. Kaada kasvisliemi kattilaan, lisää juurekset. Keitä juureksia, kunnes ne ovat pehmenneitä ja kypsiä. \n3. Kun juurekset ovat kypsiä, soseuta keitto blenderillä tai sauvasekoittimella. Ole varovainen, kuuma keitto roiskuu helposti! \n4. Kaada tarvittaessa keitto takaisin kattilaan. Lisää mausteet ja kerma, sekoita huolellisesti. Maista ja mausta lisää tarvittaessa. Jos keitto tuntuu liian paksulta, lisää runsaammin kermaa.";
                    previous.interactable = false;
                    
                    
                    break;

                  case 2:
                   
                    ingredients.text = "2 annosta \n\n300 g jauhoista perunaa \n200 g porkkanaa \n100 g juuriselleriä \n100 g palsternakka \n6 dl kasvislientä1 dl kermaa tai maitoa \n2 tl Valkopippuria \nSuolaa maun mukaan";
                    recipe.text = "Juuressosekeitto";
                    instructions.text = "1. Kuori perunat, porkkanat, juuriselleri ja palsternakka. Leikkaa juurekset tasakokoisiksi paloiksi. \n2. Kaada kasvisliemi kattilaan, lisää juurekset. Keitä juureksia, kunnes ne ovat pehmenneitä ja kypsiä. \n3. Kun juurekset ovat kypsiä, soseuta keitto blenderillä tai sauvasekoittimella. Ole varovainen, kuuma keitto roiskuu helposti! \n4. Kaada tarvittaessa keitto takaisin kattilaan. Lisää mausteet ja kerma, sekoita huolellisesti. Maista ja mausta lisää tarvittaessa. Jos keitto tuntuu liian paksulta, lisää runsaammin kermaa.";
                    
                    
                    break;

                    case 3:
                    ingredients.text = "4 annosta \n\n200 g silakkafilettä \n800g kiinteitä perunoita (n. 6-8 perunaa) \n1 sipuli \n1dl kermaa/maitoa \n3dl kalalientä \nloraus öljyä \n1 tl maustepippuria, lisää maun mukaan \nsuolaa maun mukaan \nHienonnettua tilliä maun mukaan";
                    recipe.text = "Silakkalaatikko";
                    instructions.text = "1. Kuori perunat ja siivuta ne ohuiksi siivuiksi. Leikkaa silakkafileet paloiksi. \n2. Keitä perunaviipaleita kattilassa n. 10min. Viipaleiden ei tarvitse olla kypsiä! Valuta viipaleet ja jätä odottamaan. \n3. Leikkaa sipuli pieniksi kuutioiksi. \n4. Lorauta syvälle paistinpannulle öljyä ja lisää sipulit. Kuullota, kunnes sipuli on hiukan läpikuultavaa. \n5. Lisää pannulle perunat, kala sekä nesteet. Mausta. Peitä kannella ja hauduta kunnes kala kypsää ja perunat pehmeitä haarukalla tuikatessa. Kypsennysaika riippuu vahvasti siitä, kuinka ohuiksi perunat on leikattu.";
                    next.interactable = true;
                    
                    break;

                    case 5:
                    ingredients.text = "4 annosta \n\n8dl Marja / hedelmämehua, sokeroimatonta \n1 dl valitsemiasi marjoja tai hedelmänpaloja \n1dl sokeria \n5 rlk perunajauhoa";
                    recipe.text = "Mehukiisseli";
                    instructions.text = "1. Sekoita kattilassa kaikki ainesosat sekaisin. \n2. Kuumenna miedolla lämmöllä kiisseliä sekoittaen jatkuvasti, kunnes näet ensimmäisen kuplan pulpahtavan pintaan. \n3. Kun ensimmäinen iso kupla näkyy, ota kiisseli pois lämmöltä ja anna sen jäähtyä. \n4. Tarjoile esimerkiksi sokerin tai marjojen kanssa.";
                    next.interactable = false;
                    
                    break;

                    default:
                    // code block
                    break;

                }

        }



        public void pageFour()
        {
            
                   
                    num = 4;
                    
                    pageNum.text = "Page " + num;
                    
                     ingredients.text = "Tomaattikeitto \nAinekset\nTomaatti\nLiemikuutio\nSipuli\nOliviöljy";
                     recipe.text = "Sekoita kaikki ainekset\nSekoita tehosekoittimessa";
                       
                         
        
        }

       
    }
}
