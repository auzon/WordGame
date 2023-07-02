using UnityEngine;

public class WordDictionary : MonoBehaviour
{
    [SerializeField] private TextAsset wordsTA;
    private WordsJson wordsJson;


    public WordsJson Words
    {
        get { return wordsJson; }
    }

    private void Awake()
    {
        wordsJson = JsonUtility.FromJson<WordsJson>(wordsTA.text);
    }

    public Word GetRandomWord()
    {
        int wordLength = GameManager.Instance.WordLength;
        int index = Random.Range(0, wordsJson.words.Length);
        if (wordsJson.words[index].entry.Length == wordLength)
        {
            return wordsJson.words[index];
        }
        else
        {
            return GetRandomWord();
        }
    }

}

[System.Serializable]
public class WordsJson
{
    public Word[] words;
}

[System.Serializable]
public class Word
{
    public string entry;
    public string meaning;
}
