using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBoxList : MonoBehaviour
{
    [SerializeField] private LetterBox[] letterBoxArray;
    private GameObject cursor;
    private CurrentQuestion currentQuestion;
    private int cursorIndex;
    private Queue<int> wordLengthQueue = new Queue<int>(new int[] {4,4,5,5,6,6,7,7,8,8,9,9,10,10});

    public int CursorIndex 
    { 
        get => cursorIndex;
        set
        {
            cursorIndex = value;
            Vector3 newPosition = letterBoxArray[cursorIndex].transform.Find("BottomMiddlePoint").position;
            cursor.transform.position = newPosition;
        } 
    }

    private void Start()
    {
        cursor = transform.Find("Cursor").gameObject;
        currentQuestion = FindObjectOfType<CurrentQuestion>();
        GameManager.Instance.WordLength = wordLengthQueue.Dequeue();

        currentQuestion.OnQuestionChanged += HandleQuestionChanged;
        currentQuestion.LoadRandomQuestion();
    }

    private void HandleQuestionChanged(string meaning, string answer)
    {
        Clear();
        DeactivateAllLetterBoxes();
        ActivateRequiredLetterBoxes(answer);
        UpdateCorrectLetters(answer);
        CursorIndex = 0;
    }

    public void Clear()
    {
        Debug.Log("Clear called.");
        foreach (LetterBox letterBox in letterBoxArray)
        {
            letterBox.Clear();
        }
    }

    private void UpdateCorrectLetters(string answer)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            letterBoxArray[i].CorrectLetter = answer[i];
        }
    }

    private void DeactivateAllLetterBoxes()
    {
        foreach (LetterBox letterBox in letterBoxArray)
        {
            letterBox.Activated = false;
        }
    }

    private void ActivateRequiredLetterBoxes(string answer)
    {
        for (int i = 0; i < answer.Length; i++)
        {
            letterBoxArray[i].Activated = true;
        }
    }

    public void SetLetter(char letter)
    {
        letterBoxArray[CursorIndex].CandidateLetter = letter;
        for (int i = 0; i < letterBoxArray.Length; i++)
        {
            if (letterBoxArray[i].Activated && letterBoxArray[i].CandidateLetter == '\0')
            {
                CursorIndex = i;
                break;
            }
        }
        if (IsAllActiveBoxesCorrect())
        {
            GameManager.Instance.Score += currentQuestion.Answer.Length * 100;
            if (wordLengthQueue.Count == 0)
            {
                GameManager.Instance.State = GameManager.GameState.PlayerWon;
            }
            else
            {
                GameManager.Instance.WordLength = wordLengthQueue.Dequeue();
                currentQuestion.LoadRandomQuestion();
            }
        }
    }

    private bool IsAllActiveBoxesCorrect()
    {
        foreach (LetterBox letterBox in letterBoxArray)
        {
            try
            {
                if (!letterBox.IsCandidateCorrect())
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }

        }
        return true;
    }

    public void Backspace()
    {
        if (letterBoxArray[cursorIndex])
        {
            letterBoxArray[cursorIndex].CandidateLetter = '\0';
        }
        if (CursorIndex > 0)
        {
            CursorIndex--;
        }
    }
}
