using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreOut : MonoBehaviour
{
    [SerializeField] public ScoreManager _scoreManager;
    public TextMeshProUGUI textMeshPro;

    private void UpdateScore(int score)
    {
        textMeshPro.text = $"{score}/{MaxScore()}";
    }
    private void Awake()
    {
        
        

        _scoreManager.onScoreUpdate+=UpdateScore;
        UpdateScore(0);
    }
    private string MaxScore()
    {
        return (_scoreManager.maxScore/1000).ToString() + "K";
    }
}
