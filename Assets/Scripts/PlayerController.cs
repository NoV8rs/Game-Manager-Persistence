using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    /* Character Controller - Using CharacterBody in Unity
     * Movement - Using Rigidbody in Unity, Forwards, Backwards, Left, Right, max speed, and sprinting
     * Jumping - Using Rigidbody in Unity, Jumping with a force, max jump height, and a check for if the player is grounded
     * Camera - Using Camera in Unity, Rotating the camera with the mouse, and clamping the angle of the camera
     */
    
    private CharacterController characterController;
    
    //Speed
    public float playerSpeed = 10.0f;
    public float sprintSpeed = 15.0f;
    public float senisitivityX = 100.0f;
    public float senisitivityY = 100.0f;
    
    
    //Jumping
    float jumpForce = 8.0f;
    float maxJumpHeight = 1.0f;
    float gravity = 20.0f;
    bool isGrounded;
    
    //Camera
    public Transform playerCamera;
    public float cameraRotationLimit = 80.0f;
    private float currentCameraRotationX = 0.0f;
    
    //Player Stats
    public int level = 1;
    public int health = 100;
    public int experience = 0;
    public int money = 0;
    
    // Player Position
    public Vector3 playerPosition;
    
    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen, and hitting escape will unlock it
    }

    public void Update()
    {
        MovingRandomly();
    }
    
    public void SavePlayer()
    {
        Save_System.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = Save_System.LoadPlayer();
        level = data.level; 
        health = data.health; 
        money = data.money; 
        experience = data.experience; 
        Vector3 position; 
        playerPosition.x = data.position[0];
        playerPosition.y = data.position[1];
        playerPosition.z = data.position[2];
        SceneManager.LoadScene(data.sceneName);
    }

    public void MovingRandomly()
    {
        playerPosition.x += 1 * Time.deltaTime;
        playerPosition.z += 100 * Time.deltaTime;
        playerPosition.y += 25 * Time.deltaTime;
    }
}
