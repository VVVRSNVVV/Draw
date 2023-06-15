using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class NewBallON : MonoBehaviour
{
    //[SerializeField] Button newBallON;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;

    private Renderer renderer;


    [SerializeField] public int startCoast;
    [SerializeField] public int coastStep;
    public int coast;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    //private void Update()
    //{
    //    if (coast < _scoreManager.scoreAvailable)
    //    {
    //        newBallON.SetActive(true);
    //    }
    //    else
    //    {
    //        newBallON.SetActive(false);
    //    }
    //}
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
