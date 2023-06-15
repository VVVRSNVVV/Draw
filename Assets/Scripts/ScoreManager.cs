using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] NewBallON newBallON;
    //add merge ball


    
    public int scoreAvailable = 40;
    public int score = 0;
    public Action<int> onScoreUpdate;
    public Action<int> onScoreAveilable;


    public void scoring(int param)
    {
        score= score + param;
        scoreAvailable = scoreAvailable + param;

        onScoreUpdate?.Invoke(score);
        onScoreAveilable?.Invoke(scoreAvailable);
    }

    public void Buying(int coast)
    {
        if (coast < scoreAvailable)
        { 
        scoreAvailable = scoreAvailable - coast;
        }
        onScoreAveilable?.Invoke(scoreAvailable);
    }



}

