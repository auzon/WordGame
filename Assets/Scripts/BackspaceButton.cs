using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackspaceButton : MonoBehaviour
{
    private LetterBoxList letterBoxList;

    private void Awake()
    {
        letterBoxList = FindObjectOfType<LetterBoxList>();
    }

    private void OnMouseDown()
    {
        letterBoxList.Backspace();
    }
}
