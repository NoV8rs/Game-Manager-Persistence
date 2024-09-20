using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    // Loads the levels in Unity, using the levelName as the scene names in Unity, and having an Player spawn point in the level.
    GameManager GameManager;
    PlayerController playerController;
    
    private void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }
    
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void NewGame()
    {
        playerController.money = 0;
        playerController.experience = 0;
        playerController.level = 1;
        playerController.health = 100;
        playerController.playerPosition = new Vector3(0, 0, 0);
        
        SceneManager.LoadScene(1);
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
}
