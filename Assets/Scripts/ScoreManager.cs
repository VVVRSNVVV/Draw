using System;
using UnityEngine;
using ZergRush.ReactiveCore;

public class ScoreManager : MonoBehaviour
{
    public int maxScore;

    public event Action onComplited;
    private bool isComplited;

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
        scoreAvailable += param * ComboHandler.Instance.combo;

        onScoreUpdate?.Invoke(score);
        if (score >= maxScore && !isComplited) 
        {
            isComplited = true;
            onComplited?.Invoke();
        }
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

