using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnRemainingTimeDecreases : UnityEvent<float> { }


public class Timer : MonoBehaviour
{
    [SerializeField] private int startTimeSeconds;
    [SerializeField] private float remainingTimeSeconds;
    private TimerState state;

    public OnRemainingTimeDecreases OnRemaningTimeDecreases;
    public UnityEvent OnRemainingTimeReachesZero;

    public TimerState State
    {
        get => state;
        set
        {
            state = value;
            switch (State)
            {
                case TimerState.Countdown:
                    break;
                case TimerState.Paused:
                    break;
                case TimerState.Finished:
                    GameManager.Instance.State = GameManager.GameState.PlayerLose;
                    break;
            }
        }
    }

    private void Start()
    {
        remainingTimeSeconds = startTimeSeconds;
    }

    private void Update()
    {
        if (State == TimerState.Countdown)
        {
            CountDown();
        }
    }

    private void CountDown()
    {
        if (remainingTimeSeconds <= 0)
        {
            State = TimerState.Finished;
            return;
        }
        remainingTimeSeconds -= Time.deltaTime;
        OnRemaningTimeDecreases.Invoke(remainingTimeSeconds);
    }

    public enum TimerState
    {
        Countdown,
        Paused,
        Finished,
    }
}
