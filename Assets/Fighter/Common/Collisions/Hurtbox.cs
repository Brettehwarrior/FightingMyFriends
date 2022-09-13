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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TryHit(collision);
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            TryHit(collision);
        }

        private void TryHit(Collider2D collision)
        {
            var hitObject = collision.gameObject;
            
            // Check if the object is already in the list
            if (_hitObjects.Contains(hitObject))
            {
                return;
            }
            
            var hittable = hitObject.GetComponent<IHittable>();
            if (hittable == null)
                return;
            
            // Flip direction based on transform rotation
            // TODO: This depends on heirarchy structure
            var hitboxRotation = transform.parent.parent.rotation;
            Debug.Log(hitboxRotation.eulerAngles);
            bool shouldFlip = Mathf.Abs(hitboxRotation.eulerAngles.y) > 0f;
            
            hittable.Hit(_hurtboxData, shouldFlip);
            _hitObjects.Add(hitObject);
        }

        private void OnDisable()
        {
            // Empty list of hit objects
            _hitObjects.Clear();
        }
    }
}