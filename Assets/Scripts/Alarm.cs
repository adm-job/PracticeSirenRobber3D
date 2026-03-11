using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Door _door;

    private void OnEnable()
    {
        _door.Opening += PlaySiren;
    }
    private void OnDisable()
    {
        _door.Opening -= PlaySiren;
    }

    private void PlaySiren()
    {
        Debug.Log("ALARM");
        _audioSource.Play();
    }
}

