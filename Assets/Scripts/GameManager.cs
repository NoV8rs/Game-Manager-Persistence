using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Script is used to manage the game, and the game states.
    public static GameManager Instance { get; private set; }
    public PlayerController playerController;
    public PlayerUI playerUI;
    public LoadingLevel loadingLevel;
    public enum GameState { MainMenu, Playing, Paused, GameOver }
    
    
    
    public GameState gameState;
    
    private void Start()
    {
        gameState = GameState.MainMenu;
    }
    
    private void Update()
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.Playing:
                Playing();
                break;
            case GameState.Paused:
                PauseGame();
                break;
            case GameState.GameOver:
                GameOver();
                break;
        }
    }
    
    public void MainMenu()
    {
        gameState = GameState.MainMenu;
        playerUI.MainMenu();
        Cursor.visible = true;
    }
    
    public void PauseGame()
    {
        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape) && gameState == GameState.Playing)
        {
            Time.timeScale = 0;
            gameState = GameState.Paused;
            playerUI.PauseGame();
            Cursor.visible = true;
        }
        // Unpause the game
        else
        if (gameState == GameState.Paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                gameState = GameState.Playing;
                playerUI.PlayerHUD();
                Cursor.visible = false;
            }
        }
    }
    
    public void GameOver()
    {
        gameState = GameState.GameOver;
    }
    
    public void Playing()
    {
        gameState = GameState.Playing;
        playerUI.PlayerHUD();
        Cursor.visible = false;
    }

    public void SpawnPlayer()
    {
        GameObject spawnPoint = GameObject.FindWithTag("PlayerSpawn");
        if (loadingLevel.CompareTag("PlayerSpawn"))
        {
            playerController.Player = GameObject.FindWithTag("Player");
            playerController.Player.transform.position = loadingLevel.transform.position;
            Debug.Log("Player has spawned");
        }
    }
    
    
    
}
