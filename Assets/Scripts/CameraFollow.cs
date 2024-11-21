using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    private Vector2 _input;
    private Vector3 _rotate;
    private CameraRotation _cameraRotation;
    [SerializeField] private MouseSensitivity _mouseSensitivity;
    [SerializeField] private CameraAngle _cameraAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _input.x = Input.GetAxis("Mouse X");
        _input.y = Input.GetAxis("Mouse Y");
        _cameraRotation.Yaw += _input.x * _mouseSensitivity.horizontal * Time.deltaTime;
        _cameraRotation.Pitch += _input.y * _mouseSensitivity.vertical * Time.deltaTime;
        _cameraRotation.Pitch = Mathf.Clamp(_cameraRotation.Pitch,_cameraAngle.min ,_cameraAngle.max);
    }

    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRotation.Pitch, _cameraRotation.Yaw, 0.0f);
        Vector3 targetPos = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref _currentVelocity, smoothTime);
    }
}

[Serializable]
public struct MouseSensitivity
{
    public float horizontal;
    public float vertical;
}

public struct CameraRotation
{
    public float Pitch;
    public float Yaw;
}
[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}

