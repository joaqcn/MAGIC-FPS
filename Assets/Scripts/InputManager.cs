using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFootActions;
    private PlayerMoto playerMoto;
    private Vector2 movementVector;
    private PlayerLook playerLook;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFootActions = playerInput.OnFoot;
        playerMoto = GetComponent<PlayerMoto>();
        onFootActions.Jump.performed += ctx => playerMoto.Jump();
        playerLook = GetComponent<PlayerLook>();
        onFootActions.Crouch.performed += ctx => playerMoto.Crouch();
        onFootActions.Sprint.performed += ctx => playerMoto.Sprint();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMoto.ProcessMove(onFootActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(onFootActions.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFootActions.Enable();
    }
    private void OnDisable()
    {
        onFootActions.Disable();
    }
}
