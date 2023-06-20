using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class MergeBalls : MonoBehaviour
{
    [SerializeField] Button mergeBalls;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;
    private bool mergeValid = false;

    public event Action<int> onCoastUpdate;

    [SerializeField] public float coastStep;
    [SerializeField] public int coast;





    public List<GameObject> balls => _ballCreator.balls;

    private void Awake()
    {
        _scoreManager.scoreAvailableCell.ListenUpdates(UpdateVisibility);
        mergeBalls.onClick.AddListener(Merge);
    }

    private void UpdateVisibility(int scoreAvailable)
    {

        if (coast <= scoreAvailable && CanMerge())
        {
            mergeBalls.interactable=true;
        }
        else
        {
            mergeBalls.interactable=false;
        }
        
    }
  
    private void Pricing()
    {
        coast = Mathf.RoundToInt(coast * coastStep);
        onCoastUpdate?.Invoke(coast);
    }
    private bool CanMerge()
    {
        Dictionary<int, List<BallScript>> map = new Dictionary<int, List<BallScript>>();
        foreach (var ball in balls.Select(b => b.GetComponent<BallScript>()))
        {
            if (map.ContainsKey(ball.ballType))
            {
                map[ball.ballType].Add(ball);
            }
            else
            {
                map[ball.ballType] = new List<BallScript>();
                map[ball.ballType].Add(ball);
            }
        }
        foreach (var kvp in map)
        {
            if (kvp.Value.Count >=3)
            {
                return true;
            }
        }
        return false;
    }

    public void Merge()
    {

        //delete 3 same balls and spawn nex type ball
        Dictionary<int, List<BallScript>> map = new Dictionary<int, List<BallScript>>();
        foreach (var ball in balls.Select(b => b.GetComponent<BallScript>()))
        {
            if (map.ContainsKey(ball.ballType))
            {
                map[ball.ballType].Add(ball);
            }
            else
            {
                map[ball.ballType] = new List<BallScript>();
                map[ball.ballType].Add(ball);
            }
        }
        foreach (var kvp in map)
        {
            if (kvp.Value.Count >=3)
            {
                Merge(kvp.Value.Take(3).ToList());
                //
                _scoreManager.Buying(coast);
                Pricing();
                return;
            }
        }
    }
    private void Merge(List<BallScript> balls)
    {
        var ballType = balls[0].ballType;
        if (ballType == 5)
        { return; }
        else
        {

            
            ballType = (ballType + 1);
            BallMergeAnimator.Instance.Animate(balls);
            _ballCreator.SpawnObject(ballType);
            foreach (var ball in balls)
            {
                this.balls.Remove(ball.gameObject);
                Destroy(ball.gameObject);
            }

        }
    }



}
