using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] NewBallON newBallON;
    //add merge ball


    
    public Cell<int> scoreAvailableCell = new Cell<int>(40);
    public int scoreAvailable
    {
        get => scoreAvailableCell.value;
        set => scoreAvailableCell.value = value;
    }
    public int score = 0;
    public Action<int> onScoreUpdate;
    public Action<int> onScoreAveilable;


    public void scoring(int param)
    {
        score= score + param;
        scoreAvailable += param;

        onScoreUpdate?.Invoke(score);
    }

    public void Buying(int coast)
    {
        if (coast <= scoreAvailable)
        { 
        scoreAvailable -= coast;
            Debug.Log(coast);
        }
    }



}

