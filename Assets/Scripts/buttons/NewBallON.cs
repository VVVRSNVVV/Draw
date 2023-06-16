using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;


public class NewBallON : MonoBehaviour
{
    [SerializeField] Button newBallON;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;

    public event Action<int> onCoastUpdate;




   
    [SerializeField] public float coastStep;
    [SerializeField] public int coast;

    private void Awake()
    {
        _scoreManager.scoreAvailableCell.ListenUpdates(UpdateVisibility);
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
            newBallON.interactable=false;
        }
    }
    private void Pricing()
    {
        coast = Mathf.RoundToInt(coast * coastStep);
        onCoastUpdate?.Invoke(coast);
    }

    public void NewBall()
    {
        _scoreManager.Buying(coast);
        _ballCreator.SpawnObject();
        Pricing();
    }



}
