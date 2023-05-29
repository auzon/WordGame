using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterBox : MonoBehaviour
{
    // fields
    private string correctLetter;
    private string displayedLetter;
    private bool activated;

    // components
    private TextMeshPro textMeshPro;
    private SpriteRenderer spriteRenderer;

    public bool Activated
    {
        get { return activated; }
        set 
        {
            if (value is true) onActivated();
            else onDeactivated();
            activated = value; 
        }
    }

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void onDeactivated()
    {
        spriteRenderer.color = new Color(0f, 0.39f, 0.36f);
    }

    private void onActivated()
    {
        spriteRenderer.color = new Color(0f, 0.8f, 0.8f);
    }
}
