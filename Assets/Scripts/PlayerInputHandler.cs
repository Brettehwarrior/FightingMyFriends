using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = System.Object;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    
    // Input actions
    private InputAction _moveAction;
    private InputAction _jumpAction;
    
    // Private variables
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        
        _moveAction = _playerInput.actions["Move"];
        _jumpAction = _playerInput.actions["Jump"];
    }
    
    private void Start()
    {
        _moveAction.performed += Move;
        _moveAction.canceled += Move;
        _jumpAction.performed += Jump;
        _jumpAction.canceled += Jump;
    }

    private void OnDestroy()
    {
        _moveAction.performed -= Move;
        _moveAction.canceled -= Move;
        _jumpAction.performed -= Jump;
        _jumpAction.canceled -= Jump;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        var direction = ctx.ReadValue<Vector2>();
        MovementInput = direction;
    }
    
    private void Jump(InputAction.CallbackContext ctx)
    {
        JumpInput = ctx.ReadValue<float>() != 0f;
    }
}
