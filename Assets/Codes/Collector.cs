using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FusilliProject
{
    public class Collector : MonoBehaviour
    {


			
       private void OnTriggerEnter2D(Collider2D other)
		{
			Collectable collectable = other.GetComponent<Collectable>();

            AddScore b = GetComponent<AddScore>();

            b.AddPoint(collectable.Score);
            
			if (collectable != null)
			{
                
				Debug.Log("Object collected! " + collectable.Score + " awarded!");
				// TODO: Add score
				Destroy(other.gameObject);

                
			}

		}
    }
}
