using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* Character Controller - Using CharacterBody in Unity
     * Movement - Using Rigidbody in Unity, Forwards, Backwards, Left, Right, max speed, and sprinting
     * Jumping - Using Rigidbody in Unity, Jumping with a force, max jump height, and a check for if the player is grounded
     * Camera - Using Camera in Unity, Rotating the camera with the mouse, and clamping the angle of the camera
     */
    
    private CharacterController characterController;
    public GameObject Player;
    
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
    
    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen, and hitting escape will unlock it
    }

    public void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        PlayerMoves();
        
        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        
        //Saving and Loading
        SavePlayer();
        LoadPlayer();
    }

    public void PlayerMoves()
    {
        // Player moving forwards, backwards, left, right, with Camera Rotation.
        // Player Movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * playerSpeed);
        
        // Mouse Rotation
        float rotation = Input.GetAxis("Mouse X") * senisitivityX * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        float cameraRotation = Input.GetAxis("Mouse Y") * senisitivityY * Time.deltaTime;
        currentCameraRotationX -= cameraRotation;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        playerCamera.localEulerAngles = new Vector3(currentCameraRotationX, 0, 0);
    }
    
    public void Jump()
    {
        if (isGrounded)
        {
            float jumpHeight = Mathf.Sqrt(2 * gravity * maxJumpHeight);
            characterController.Move(Vector3.up * jumpHeight * Time.deltaTime);
        }
        else
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
    
    public void Sprint()
    {
        playerSpeed = sprintSpeed;
    }
    
    public void SavePlayer()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Save_System.SavePlayer(this);
        }
    }

    public void LoadPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerData data = Save_System.LoadPlayer();
            level = data.level;
            health = data.health;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;
        }
    }




}
