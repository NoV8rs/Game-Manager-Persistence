using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    // Loads the levels in Unity, using the levelName as the scene names in Unity, and having an Player spawn point in the level.
    GameManager GameManager;
    
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
}
