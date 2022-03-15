using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FusilliProject
{
    public class LevelSelection : MonoBehaviour
    {
        public void ChangeScene()
        {
            SceneManager.LoadScene("KitchenProto");
            Debug.Log("To Game");
        }
    }
}
