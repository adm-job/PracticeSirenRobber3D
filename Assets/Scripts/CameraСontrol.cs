using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraСontrol : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speedMouse = 100f;

    private float _xRotation = 0;
    private float _minAngle = -90f;
    private float _maxAngle = 90f;
    private float mouseX;
    private float mouseY;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * _speedMouse * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * _speedMouse * Time.deltaTime;
    
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _minAngle, _maxAngle);

        transform.localRotation = Quaternion.Euler( _xRotation,0, 0);

        _player.Rotate(Vector3.up * mouseX);
    }
}
