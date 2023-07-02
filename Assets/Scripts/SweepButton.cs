using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SweepButton : MonoBehaviour
{
    [SerializeField] private UnityEvent OnClick;

    private void OnMouseDown()
    {
        OnClick?.Invoke();
    }
}
