using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Action<int> onScoreUpdate;
    

    public void scoring(int param)
    {
        score= score + param;
        Debug.Log("Score: " + score);
        onScoreUpdate?.Invoke(score);
    }

}

