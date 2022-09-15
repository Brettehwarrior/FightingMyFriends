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
            // It's actually kind of disgusting
            
            var hitboxRotation = transform.parent.parent.rotation;
            Debug.Log(hitboxRotation.eulerAngles);
            bool shouldFlip = Mathf.Abs(hitboxRotation.eulerAngles.y) > 0f;
            
            // Do hit
            hittable.Hit(_hurtboxData, shouldFlip);
            
            // Do hitpause effect
            HitEffectManager.Instance.PauseEffect(new []{transform.parent.parent.parent.parent.gameObject, hitObject}, _hurtboxData.hitStop);
            
            // Spawn hit effect
            if (_hurtboxData.hitEffectPrefab != null)
            {
                var position = collision.ClosestPoint(transform.position);
                var effectPosition = new Vector3(position.x, position.y, transform.position.z-0.5f);
                Instantiate(_hurtboxData.hitEffectPrefab, effectPosition, Quaternion.identity);
            }
            
            // Add hit target to no hit list
            _hitObjects.Add(hitObject);
        }

        private void OnDisable()
        {
            // Empty list of hit objects
            _hitObjects.Clear();
        }
    }
}