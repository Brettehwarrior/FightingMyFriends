using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRigidbodyOnDisable : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private Vector2 _velocity;
    private float _angularVelocity;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnDisable()
    {
        _velocity = _rb.velocity;
        _angularVelocity = _rb.angularVelocity;
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.velocity = Vector2.zero;
        _rb.angularVelocity = 0;
    }
    
    private void OnEnable()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.velocity = _velocity;
        _rb.angularVelocity = _angularVelocity;
    }
}
