using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewBallON : MonoBehaviour
{
    [SerializeField] Button newBallON;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;

    


    [SerializeField] public int startCoast;
    [SerializeField] public int coastStep;
    public int coast = 10;

    private void Awake()
    {
        _scoreManager.onScoreAveilable+= UpdateVisibility;
        newBallON.onClick.AddListener(NewBall);
    }

    private void UpdateVisibility(int scoreAvailable)
    {
       
        if (coast <= scoreAvailable)
        {
            newBallON.interactable=true;
        }
        else
        {
            newBallON.interactable=true;
        }
    }
    private void Pricing()
    {
        coast = coast * coastStep;
    }

    public void NewBall()
    {
        _scoreManager.Buying(coast);
        //_ballCreator.SpawnObject(); send type of ball that will be spawn 

    }



}
