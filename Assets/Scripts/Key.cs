using TMPro;
using UnityEngine;

public class Key : MonoBehaviour
{
    // fields
    private string letter;

    // components
    private TextMeshPro textMeshPro;
    
    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Pressed key: " + textMeshPro.text);
    }
}
