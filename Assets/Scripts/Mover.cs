using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 500f;
    [SerializeField] private CharacterController _controller;

    private float x;
    private float z;
    private string _horizontal = "Horizontal";
    private string _vertical = "Vertical";


    private void Update()
    {
        x = Input.GetAxis(_horizontal);
        z = Input.GetAxis(_vertical);

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);
    }
}
