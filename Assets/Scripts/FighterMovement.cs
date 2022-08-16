using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    public Vector2 CurrentVelocity { get; private set; }
    
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CurrentVelocity = Vector2.zero;
    }

    private void Update()
    {
        CurrentVelocity = _rb.velocity;
    }

    public void SetHorizontalVelocity(float velocity)
    {
        var newVelocity = new Vector2(velocity, CurrentVelocity.y);
        _rb.velocity = newVelocity;
        CurrentVelocity = newVelocity;
    }
}
