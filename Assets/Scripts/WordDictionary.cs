using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    [SerializeField] private TextAsset wordsJson;
    private WordList words;

    public WordList Words
    {
        get { return words; }
    }

    private void Start()
    {
        words = JsonUtility.FromJson<WordList>(wordsJson.text);
    }

}

[System.Serializable]
public class WordList
{
    public Word[] words;
}

[System.Serializable]
public class Word
{
    public string entry;
    public string meaning;
}
