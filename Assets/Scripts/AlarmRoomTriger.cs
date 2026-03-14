using System;
using UnityEngine;

public class AlarmRoomTriger : MonoBehaviour
{
    public event Action<bool> inRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _))
        {
            inRoom?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<DoorOpener>(out _))
        {
            inRoom?.Invoke(false);
        }
    }
}
