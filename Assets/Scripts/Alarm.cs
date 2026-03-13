using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Door _door;
    [SerializeField] private AlarmRoomTriger _alarmRoomTriger;

    private bool _isOpenDoor = false;
    private bool _isRoomAlarm = false;

    private void OnEnable()
    {
        _door.Opening += PlaySiren;
        _alarmRoomTriger.inRoom += OpenRoom;
    }

    private void OnDisable()
    {
        _door.Opening -= PlaySiren;
        _alarmRoomTriger.inRoom -= OpenRoom;
    }

    private void Awake()
    {
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_isRoomAlarm && _isOpenDoor)
        {
            _audioSource.Play();
            StartCoroutine(TurnUpVolume());
        }
        else
        {
            StopCoroutine(TurnUpVolume());
        }
    }

    private void PlaySiren()
    {
        _isOpenDoor = true;

    }

    private void OpenRoom(bool isOpen)
    {
        _isRoomAlarm = isOpen;
    }

    private IEnumerator TurnUpVolume()
    {
        while (enabled)
        {
            if (_audioSource.volume <= 1)
            {
                _audioSource.volume += 0.002f;
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }


}

