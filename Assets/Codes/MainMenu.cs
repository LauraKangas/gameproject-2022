using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FusilliProject
{
    public class MainMenu : MonoBehaviour
    {
        
        public void ChangeScene()
        {
            SceneManager.LoadScene("LevelSelection");
            Debug.Log("To level selection");
        }

        public void resetScene()
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("reset");
        }
    }
}
