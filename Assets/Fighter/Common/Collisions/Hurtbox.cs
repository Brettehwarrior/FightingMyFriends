using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fighter.Common.Collisions
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] private HurtboxData _hurtboxData;
        
        // List to keep track of objects already hit
        private readonly List<GameObject> _hitObjects = new List<GameObject>();

        private void OnCollisionEnter(Collision collision)
        {
            // Check if the object is already in the list
            if (_hitObjects.Contains(collision.gameObject))
            {
                return;
            }
            
            
            
            // Add the object to the list
            _hitObjects.Add(collision.gameObject);
        }
    }
}