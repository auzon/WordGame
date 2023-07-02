using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    TextMeshPro scoreNumberTMP;

    void Awake()
    {
        scoreNumberTMP = GetComponent<TextMeshPro>();
        GameManager.Instance.OnScoreChange += HandleScoreChange;
    }

    private void HandleScoreChange(int newScore)
    {
        scoreNumberTMP.text = newScore.ToString();
    }

}
