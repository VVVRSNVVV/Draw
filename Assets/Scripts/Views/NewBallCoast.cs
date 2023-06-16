using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBallCoast : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] NewBallON _newBallON;

   

    private void Awake()
    {
        _newBallON.onCoastUpdate+= UpdateScore;
        UpdateScore(_newBallON.coast);
    }

    private void UpdateScore(int score)
    {
        label.text = $"${score}";
    }
}
