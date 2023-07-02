using System;
using TMPro;
using UnityEngine;

public class LetterBox : MonoBehaviour
{
    // fields
    private char correctLetter = '-';
    private char candidateLetter = '\0';
    private bool activated;

    // components
    private TextMeshPro textMeshPro;
    private SpriteRenderer spriteRenderer;

    public bool Activated
    {
        get { return activated; }
        set 
        {
            if (value is true) OnActivated();
            else OnDeactivated();
            activated = value; 
        }
    }

    public char CorrectLetter { get => correctLetter; set => correctLetter = value; }
    public char CandidateLetter 
    { 
        get => candidateLetter;
        set
        {
            candidateLetter = value;
            textMeshPro.text = candidateLetter.ToString();
        }
    }

    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Activated = false;
    }

    public void Clear()
    {
        CandidateLetter = '\0';
    }

    private void OnDeactivated()
    {
        spriteRenderer.color = new Color(0f, 0.39f, 0.36f);
    }

    private void OnActivated()
    {
        spriteRenderer.color = new Color(0f, 0.8f, 0.8f);
    }

    public bool IsCandidateCorrect()
    {
        System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
        if (!Activated)
        {
            throw new Exception("Letter box is not activated.");
        }
        else if (CorrectLetter.ToString().ToLower() == CandidateLetter.ToString().ToLower())
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
