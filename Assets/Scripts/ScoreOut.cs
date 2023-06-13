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
        textMeshPro.text = $"score {score}";
    }
    private void Awake()
    {
        
        textMeshPro = GetComponent<TextMeshProUGUI>();

        _scoreManager.onScoreUpdate+=UpdateScore;
        UpdateScore(0);
    }
}
