using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterBox : MonoBehaviour
{
    private TextMeshPro letter;

    private void Start()
    {
        letter = GetComponentInChildren<TextMeshPro>();
    }
}
