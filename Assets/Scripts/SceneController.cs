using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    SceneController.cs
    Author: James
    Desc: This script loads different scenes using its function
*/
public class SceneController : MonoBehaviour
{
    public void Start()
    {
    }

    public void LoadScene(int sceneIndex) // Get the index of the scene desired to go to
    {
        SceneManager.LoadSceneAsync(sceneIndex); // Use the specified index to load a different scene
    }
}
