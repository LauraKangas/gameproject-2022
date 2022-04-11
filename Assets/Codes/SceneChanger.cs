using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FusilliProject
{
    public class SceneChanger : MonoBehaviour
    {

        [SerializeField]
        private string scene;
        
        public void ChangeScene()
        {
            SceneManager.LoadScene(scene);
            Debug.Log("To " + scene);
        }

       
    }
}
