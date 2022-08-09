using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private FighterMovement _fighterMovement;
    [SerializeField] private Animator _animator;
    
    private PlayerInput _playerInput;
    
    // Input actions
    private InputAction _moveAction;
    
    // Private variables
    private Vector2 _movement;
    
    private void Awake()
    {
        _fighterMovement = GetComponent<FighterMovement>();
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
        _movement = direction;
        
        _fighterMovement.Move(direction.x);
        
        _animator.SetFloat("MoveSpeed", direction.magnitude);
    }
}
