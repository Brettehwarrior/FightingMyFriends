using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackTargets : MonoBehaviour
{
    [SerializeField] private List<Transform> targets;
    [SerializeField] private float smoothTime = 0.5f;
    [SerializeField] private float minZoom = 40f;
    [SerializeField] private float maxZoom = 10f;

    private Vector3 _offset;
    private Vector3 _velocity;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _offset = transform.position;
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        
        Move();
        Zoom();
    }
    
    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, smoothTime);
    }
    
    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / 5);
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, newZoom, Time.deltaTime);
    }
    
    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    
    private Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}
