using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MergeBalls : MonoBehaviour
{
    [SerializeField] Button mergeBalls;
    [SerializeField] ScoreManager _scoreManager;
    [SerializeField] BallCreator _ballCreator;
    private bool isAnimating = false;
   

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
        if (isAnimating) { return; }
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
        if (isAnimating) { return; }
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
        mergeBalls.interactable = false;
        isAnimating = true;
        var ballType = balls[0].ballType;
        if (ballType == 5)
        { return; }
        else
        {

            
            ballType = (ballType + 1);
            BallMergeAnimator.Instance.Animate(balls, ()=> { isAnimating = false;
                mergeBalls.interactable=true;
            });
            _ballCreator.SpawnObject(ballType);
            foreach (var ball in balls)
            {
                this.balls.Remove(ball.gameObject);
                Destroy(ball.gameObject);
            }

        }
    }



}
