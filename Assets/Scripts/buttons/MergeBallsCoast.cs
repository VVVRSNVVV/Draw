using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MergeBallsCoast : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] MergeBalls _mergeBalls;



    private void Awake()
    {
        _mergeBalls.onCoastUpdate+= UpdateScore;
        UpdateScore(_mergeBalls.coast);
    }

    private void UpdateScore(int score)
    {
        label.text = $"${score}";
    }
}
