using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private readonly int OpenTriger = Animator.StringToHash("Open");

    [SerializeField] private Animator _animator;

    public void Open()
    {
        _animator.SetTrigger(OpenTriger);
    }
}
