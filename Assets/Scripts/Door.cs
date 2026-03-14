using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private readonly int OpenTriger = Animator.StringToHash("Open");

    public event Action Opening;

    public void Open()
    {
        Opening?.Invoke();
        _animator.SetTrigger(OpenTriger);
    }
}
