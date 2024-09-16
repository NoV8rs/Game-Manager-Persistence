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
    

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen, and hitting escape will unlock it
    }

    public void Update()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        // Movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * playerSpeed);
        
        // Mouse Rotation
        float rotation = Input.GetAxis("Mouse X") * senisitivityX * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        float cameraRotation = Input.GetAxis("Mouse Y") * senisitivityY * Time.deltaTime;
        playerCamera.Rotate(-cameraRotation, 0, 0);
        
        
        
        
        
    }




}
