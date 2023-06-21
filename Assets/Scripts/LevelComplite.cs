using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplite : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] ScoreManager _scoreManager;
    private float maxValue => _scoreManager.maxScore;


    private void LateUpdate()
    {
        image.fillAmount = (float)_scoreManager.score / maxValue;
    }



}
