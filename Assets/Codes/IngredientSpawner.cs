using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

/**
Skripti aines-spawnerin funktionaalisuuden määrittelylle

Määrittää ainesten spawnauksen, spawnattavien objektien paikan, sekä kertoo spawnatulle ainekselle, että sitä painetaan


@author Johan Lummeranta
@version 1.00, 15.3.2022

*/

namespace FusilliProject
{
    public class IngredientSpawner : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        [SerializeField]
        // Viittaus spawnattavan aineksen prefabiin
        private GameObject ingredientPrefab;
        // Viittaus juuri spawnattuun ainekseen
        private GameObject ingredient;
        // Viittaus juuri spawnatun aineksen Controlleriin
        private Draggable ingredientDragger;

        [SerializeField]
        private Sprite sprite;


        // Uuden aines-olion spawnaus metodi
        private void Spawn()
        {
            // Asetetaan viittaus luotuun aines-olioon
            ingredient = Instantiate(ingredientPrefab, transform.position, transform.rotation);
        }

        // Kuuntelija, kun pelaaja painaa sormen spawnerille
        // Kutsuu Spawn-metodia, asettaa viittauksen luodun olion Controlleriin ja ilmoittaa luodulle ainekselle, että sitä painetaan
        //!!Korvattu DragHandlereillä!!
        // public void OnPointerDown(PointerEventData eventData)
        // {
        //     Spawn();

        //     // !! Alla olevat tarpeettomia, jos halutaan aineksen spawnaavan muualle kuin mihin pelaaja painaa
        //     // Asetetaan viittaus luodun aineksen Controlleriin
        //     ingredientScript = ingredient.GetComponent<IngredientController>();

        //     // Kutsutaan luodun aineksen Controllerin painamismetodia, jotta se tietää olevansa painettavana
        //     ingredientScript.OnPointerDown(eventData);
        // }

        // !!Tarpeeton jos halutaan aineksen spawnaavan muualle kuin mihin pelaaja painaa!!
        // Kuuntelija, kun pelaaja nostaa sormen ruudulta painettuaan spawneria
        // Ilmoittaa luodulle ainekselle, että sitä ei enää paineta
        //!!Korvattu DragHandlereillä!!
        // public void OnPointerUp(PointerEventData eventData)
        // {
        //     // // Kutsutaan luodun aineksen Controllerin painamisen lopetus-metodia, jotta se tietää ettei sitä enää paineta
        //     // ingredientScript.OnPointerUp(eventData);

        //     this.OnEndDrag(eventData);

        // }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Spawn();

            // !! Alla olevat tarpeettomia, jos halutaan aineksen spawnaavan muualle kuin mihin pelaaja painaa
            // Asetetaan viittaus luodun aineksen Controlleriin
            ingredientDragger = ingredient.GetComponent<Draggable>();

            ingredientDragger.OnBeginDrag(eventData);

            if (this.tag != null)
            {
                if (this.tag == "PersistentSpawner")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }

        public void OnDrag(PointerEventData eventdata)
        {
            ingredientDragger.OnDrag(eventdata);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ingredientDragger.OnEndDrag(eventData);
            if (this.tag != null)
            {
                if (this.tag == "PersistentSpawner")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
                }
            }
        }
    }
}