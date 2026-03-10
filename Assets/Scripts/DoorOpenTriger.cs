using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenTriger : MonoBehaviour
{
    [SerializeField] private Door _door;

    private bool _isOpened = false;
    private bool _hasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _))
        {
            _hasOpener = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _))
        {
            _hasOpener = true;
        }
    }

    private void Update()
    {
        if (_isOpened)
        {
            return;
        }

        if (_hasOpener && Input.GetKeyDown(KeyCode.E))
        {
            _door.Open();
            _isOpened = false;
        }
    }
}
