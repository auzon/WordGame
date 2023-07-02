using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentQuestion : MonoBehaviour
{
    private WordDictionary wordDictionary;
    private string meaning;
    private string answer;

    private TextMeshPro meaningTMP;


    public event Action<string, string> OnQuestionChanged;


    public string Meaning 
    {
        get => meaning; 
        set
        {
            meaning = value;
            meaningTMP.text = meaning;
        }
    }
    public string Answer { get => answer; set => answer = value; }

    private void Awake()
    {
        meaningTMP = transform.Find("Meaning").GetComponent<TextMeshPro>();
    }

    public void LoadRandomQuestion()
    {
        wordDictionary = FindFirstObjectByType<WordDictionary>();
        Word randomWord = wordDictionary.GetRandomWord();
        Meaning = randomWord.meaning;
        Answer = randomWord.entry;
        OnQuestionChanged?.Invoke(Meaning, Answer);
        Debug.Log("Answer: " + answer + " loaded.");
    }

}
