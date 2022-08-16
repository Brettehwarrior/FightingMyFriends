using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    // Input actions
    private InputAction _moveAction;
    
    // Private variables
    public Vector2 Movement { get; private set; }
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        
        _moveAction = _playerInput.actions["Move"];
    }
    
    private void Start()
    {
        _moveAction.performed += Move;
        _moveAction.canceled += Move;
    }

    private void OnDestroy()
    {
        _moveAction.performed -= Move;
        _moveAction.canceled -= Move;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        var direction = ctx.ReadValue<Vector2>();
        Movement = direction;
    }
}
