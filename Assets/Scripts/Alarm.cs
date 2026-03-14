using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Door _door;
    [SerializeField] private AlarmRoomTriger _alarmRoomTriger;

    private Coroutine _turnUp;
    private Coroutine _turnDown;
    private float _sleep = 1;
    private float _stepVolume = 0.02f;
    private float _maxVolume = 1;
    private float _minVolume = 0;

    private void Awake()
    {
        _audioSource.volume = 0;
        _audioSource.spatialBlend = 0;
    }

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

    private void PlaySiren()
    {
        _audioSource.Play();
    }

    private void OpenRoom(bool isOpen)
    {
        if (isOpen)
        {
            if (_turnDown != null)
            {
                StopCoroutine(_turnDown);
            }

            _turnUp = StartCoroutine(TurnUpVolume());
        }
        else
        {
            if (_turnUp != null)
            {
                StopCoroutine(_turnUp);
            }

            _turnDown = StartCoroutine(TurnDownVolume());
        }
    }

    private IEnumerator TurnUpVolume()
    {
        WaitForSeconds delay = new WaitForSeconds(_sleep);

        while (enabled)
        {
            if (_audioSource.volume < _maxVolume)
            {
                _audioSource.volume += _stepVolume;

                yield return delay;
            }
            else
            {
                yield break;
            }
        }
    }

    private IEnumerator TurnDownVolume()
    {
        WaitForSeconds delay = new WaitForSeconds(_sleep);

        while (enabled)
        {
            if (_audioSource.volume > _minVolume)
            {
                _audioSource.volume -= _stepVolume;

                yield return delay;
            }
            else
            {
                yield break;
            }
        }
    }


}

