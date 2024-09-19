using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Script is used to manage the game, and the game states.
    public static GameManager Instance { get; private set; }
    public PlayerUI playerUI;
    public PlayerController playerController;

    public void Update()
    {
        DebuggedLoadLevel();
        playerUI.UIChange();
    }
    
    public void DebuggedLoadLevel()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown("0"))
        {
            SceneManager.LoadScene(0);
        }
    }
    
    public void HealthValues(int amount)
    {
        playerController.health += amount;
    }
    
    public void MoneyValues(int amount)
    {
        playerController.money += amount;
    }
    
    public void ExperienceValues(int amount)
    {
        playerController.experience += amount;
    }
    
    public void LevelValues(int amount)
    {
        playerController.level += amount;
    }

    public static void DeletedPlayerData()
    {
        Save_System.DeletePlayer();
        Debug.Log("Player data has been deleted");
    }
}
