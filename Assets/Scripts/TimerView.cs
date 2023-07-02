using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    private TextMeshPro timeTMP;
    private Timer timer;

    private void Start()
    {
        timeTMP = GetComponentInChildren<TextMeshPro>();
        timer = GetComponent<Timer>();
        timer.OnRemaningTimeDecreases.AddListener(UpdateTimerText);
    }

    public void UpdateTimerText(float time)
    {
        TimeSpan timeTS = TimeSpan.FromSeconds(time);
        timeTMP.text = timeTS.ToString("%m':'ss");
    }
}
