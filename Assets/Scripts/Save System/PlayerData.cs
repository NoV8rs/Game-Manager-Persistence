using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData // Class is used to store Player Data in the game.
{
    public int level;
    public float[] position;
    public int health;
    
    public PlayerData(PlayerController player)
    {
        level = player.level;
        health = player.health;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
