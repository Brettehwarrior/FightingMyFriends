using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackTargets : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    [SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private float nearPan = 3f;
    [SerializeField] private float farPan = 20f;
    [SerializeField] private AnimationCurve panCurve;

    private Vector3 _offset;
    private Vector3 _velocity;
    private Bounds _targetBounds;

    private void Awake()
    {
        _offset = transform.position;
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }

        UpdateBounds();
        UpdatePosition();
    }

    private void UpdateBounds()
    {
        _targetBounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 1; i < targets.Count; i++)
        {
            _targetBounds.Encapsulate(targets[i].position);
        }
    }
    
    private void UpdatePosition()
    {
        var cachedPosition = transform.position;
        
        // Move
        Vector3 centerPoint = _targetBounds.center;
        Vector3 newPosition = centerPoint + _offset;
        
        // Pan
        var maxRange = (_targetBounds.size.x > _targetBounds.size.y) ? _targetBounds.size.x : _targetBounds.size.y;
        newPosition.z = nearPan + (panCurve.Evaluate( Math.Abs(maxRange / farPan)) * (farPan - nearPan));
        
        // Apply
        transform.position = Vector3.SmoothDamp(cachedPosition, newPosition, ref _velocity, smoothTime);
    }
}
