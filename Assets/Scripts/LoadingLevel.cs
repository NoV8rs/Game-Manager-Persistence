using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    // Loads the levels in Unity, using the levelName as the scene names in Unity, and having an Player spawn point in the level.
    PlayerController playerController;
    PlayerUI PlayerUI;
    GameManager GameManager;
    public string levelName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadLevel(levelName);
        }
    }
    
    public void LoadLevel(string name)
    {
        if (name == "Main Menu")
        {
            SceneManager.LoadScene("Main Menu");
            PlayerUI.MainMenu();
            Debug.Log("Main Menu Loaded");
        }
        else if (name == "Level 1")
        {
            SceneManager.LoadScene("Level 1");
            PlayerUI.PlayerHUD();
            Debug.Log("Level 1 Loaded");
        }
        else if (name == "Level 2")
        {
            SceneManager.LoadScene("Level 2");
            PlayerUI.PlayerHUD();
            Debug.Log("Level 2 Loaded");
        }
        else if (name == "Level 3")
        {
            SceneManager.LoadScene("Level 3");
            PlayerUI.PlayerHUD();
            Debug.Log("Level 3 Loaded");
        }
        else if (name == "End")
        {
            SceneManager.LoadScene("End");
            PlayerUI.GameOver();
            Debug.Log("Win Loaded");
        }
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerController = FindObjectOfType<PlayerController>();
        PlayerUI = FindObjectOfType<PlayerUI>();
        GameManager.Instance.playerController = playerController;
        GameManager.SpawnPlayer();
        
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        PlayerUI.PlayerHUD();
        Debug.Log("Main Menu Loaded");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        Debug.Log("Level 1 Loaded");
    }
}
