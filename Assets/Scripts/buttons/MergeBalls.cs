using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class MergeBalls : MonoBehaviour
{
    [SerializeField] Button mergeBalls;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;
    private bool mergeValid= false;

    public event Action<int> onCoastUpdate;

    [SerializeField] public float coastStep;
    [SerializeField] public int coast;

    public List<GameObject> balls = new List<GameObject>();

    private void Awake()
    {
        _scoreManager.scoreAvailableCell.ListenUpdates(UpdateVisibility);
        mergeBalls.onClick.AddListener(Merge);
    }

    private void UpdateVisibility(int scoreAvailable)
    {

        if (coast <= scoreAvailable)
        {
            mergeBalls.interactable=true;
        }
        else
        {
            mergeBalls.interactable=false;
        }
    }
    //private void MergeValid()
    //{
    //    int ball_coubter = 0;
    //    foreach (GameObject ball in balls)
    //    {
    //        if (line.Overlaps(ray))
    //        {
    //            lines.Remove(line);
    //            Destroy(line.gameObject);
    //            return;
    //        }

    //    }
    //}
    private void Pricing()
    {
        coast = Mathf.RoundToInt(coast * coastStep);
        onCoastUpdate?.Invoke(coast);
    }

    public void Merge()
    {
        _scoreManager.Buying(coast);
        Pricing();
        //delete 3 same balls and spawn nex type ball
    }


}
