using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace FusilliProject
{
    public class Collectable : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
		private int score;

		

		// Property, joka toimii kuin read-only tyyppinen muuttuja
		public int Score
		{
			get { return score; }
			//set { score = value; }
		}

		

		
    }
}
