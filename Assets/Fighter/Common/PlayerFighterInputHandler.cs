using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Fighter.Common
{
    public class PlayerFighterInputHandler : FighterInputHandler
    {
        private PlayerInput _playerInput;
    
        // Input actions
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _attackAction;
    
        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        
            _moveAction = _playerInput.actions["Move"];
            _jumpAction = _playerInput.actions["Jump"];
            _attackAction = _playerInput.actions["Attack"];
        }
    
        private void Start()
        {
            _moveAction.performed += Move;
            _moveAction.canceled += Move;
            _jumpAction.performed += Jump;
            _jumpAction.canceled += Jump;
            _attackAction.performed += Attack;
        }

        private void OnDestroy()
        {
            _moveAction.performed -= Move;
            _moveAction.canceled -= Move;
            _jumpAction.performed -= Jump;
            _jumpAction.canceled -= Jump;
            _attackAction.performed -= Attack;
        }

        private void LateUpdate()
        {
            // Reset rising edge bools
            JumpInput = false;
            AttackInput = false;
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

        private void Attack(InputAction.CallbackContext ctx)
        {
            AttackInput = ctx.ReadValue<float>() != 0f;
        }
    }
}
