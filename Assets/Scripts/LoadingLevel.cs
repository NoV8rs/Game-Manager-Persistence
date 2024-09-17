using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{
    // Loads the levels in Unity, using the levelName as the scene names in Unity, and having an Player spawn point in the level.
    PlayerController playerController;
    public string levelName;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hopefully Unity crashes");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger");
            LoadLevel();
        }
    }

    // Load the levels in the game using the levelName as the scene names in Unity
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
        Debug.Log(levelName + " Loaded");
    }
    
    // Just a simple quit game function, that will quit the game, if the game is built, if not it will just stop the game in the editor, and print a message to the console, that the game is quitting, and that you will probably never see this message, because the game will be closed, and the console will be closed as well, // WTF is the autocorrect doing (Only comment in this line to be human).
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Probably never going to see this message" + this);
    }
    
    public void SpawnPlayer()
    {
        if (CompareTag("PlayerSpawn"))
        {
            playerController.Player = GameObject.FindWithTag("Player");
            playerController.Player.transform.position = transform.position;
            Debug.Log("Player has spawned");
        }
    }
}
