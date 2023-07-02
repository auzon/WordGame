using TMPro;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    // fields
    private LetterBoxList letterBoxList;

    // components
    private TextMeshPro textMeshPro;
    
    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        letterBoxList = FindObjectOfType<LetterBoxList>();
    }

    private void OnMouseDown()
    {
        char letterChar = textMeshPro.text.ToCharArray()[0];
        letterBoxList.SetLetter(letterChar);
    }
}
