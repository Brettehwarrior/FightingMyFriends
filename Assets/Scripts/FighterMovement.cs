using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        // Ensure direction is between -1 and 1
        direction = Mathf.Clamp(direction, -1f, 1f);
        
        // Move the fighter
        _rb.velocity = new Vector3(direction * speed, 0, 0);
    }
}
