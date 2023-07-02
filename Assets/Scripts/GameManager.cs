using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private GameState state;
    [SerializeField] private int score;
    private int wordLength = 0;
    private Timer timer;

    public event Action<int> OnScoreChange;

    public static GameManager Instance { get => instance; }
    public GameState State 
    {
        get { return state; }
        set 
        {
            state = value;
            switch (state)
            {
                case GameState.Started:
                    break;
                case GameState.PlayerLose:
                    OnPlayerLose();
                    break;
                case GameState.PlayerWon:
                    OnPlayerWon();
                    break;
                default:
                    break;
            }
        }
    }
    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChange?.Invoke(score);
        }
    }

    public int WordLength 
    {
        get => wordLength;
        set
        { 
            if (value < 4)
            {
                return;
            }
            else if (value > 10) 
            {
                State = GameState.PlayerWon;            
            }
            else
            {
                wordLength = value;
            }
        }

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        Score = 0;
    }

    public void StartGame()
    {
        Debug.Log("Starting the game.");
        SceneManager.LoadScene("Run");
    }

    public void OnPlayerLose()
    {
        GameObject.Find("GameEndedText").GetComponent<TextMeshPro>().text = "Game Ended: Time run out!";
        Debug.Log("Game ended. Player lose.");
    }

    public void OnPlayerWon()
    {
        timer.State = Timer.TimerState.Paused;
        GameObject.Find("GameEndedText").GetComponent<TextMeshPro>().text = "Game Ended: You won!";
        Debug.Log("Game ended. Player won.");
    }

    public void QuitFromTheGame()
    {
        Debug.Log("Quitting from the application.");
        Application.Quit();
    }

    public enum GameState
    {
        Started,
        PlayerLose,
        PlayerWon,
    }
}
