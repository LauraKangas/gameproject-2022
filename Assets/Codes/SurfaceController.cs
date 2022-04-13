using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class SurfaceController : MonoBehaviour
    {
        public List<Draggable> ingredients;
        public GameObject[] tableSlots;

        public bool[] availabilities;

        public int FindSlot(Draggable ingredient)
        {
            ingredients.Add(ingredient);
            for (int i = 0; i < tableSlots.Length ; i++)
            {
                if (availabilities[i])
                {
                    ingredient.startPos = tableSlots[i].transform.position;
                    availabilities[i] = false;
                    return i;
                }
            }
            ingredient.startPos = tableSlots[0].transform.position;
            return 0;
        }
    }
}
