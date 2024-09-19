using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData // Class is used to store Player Data in the game.
{
    public int level;
    public float[] position;
    public int health;
    public int money;
    public int experience;
    public string sceneName;
    
    public PlayerData(PlayerController player)
    {
        level = player.level;
        health = player.health;
        money = player.money;
        experience = player.experience;
        // Scene save for what scene the player is in.
        sceneName = SceneManager.GetActiveScene().name;
        
        position = new float[3];
        position[0] = player.playerPosition.x;
        position[1] = player.playerPosition.y;
        position[2] = player.playerPosition.z;
    }
}
