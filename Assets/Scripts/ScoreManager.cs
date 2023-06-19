using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] NewBallON newBallON;
    //add merge ball



    private Cell<int> _scoreAvailableCell;
    public Cell<int> scoreAvailableCell { get {
            if (_scoreAvailableCell != null) { return _scoreAvailableCell; }
            _scoreAvailableCell = new Cell<int>(initialScoreAvailable);
            return _scoreAvailableCell;
        } }
    [SerializeField] private int initialScoreAvailable;
    public int scoreAvailable
    {
        get => scoreAvailableCell.value;
        set => scoreAvailableCell.value = value;
    }
    public int score = 0;
    public Action<int> onScoreUpdate;


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

