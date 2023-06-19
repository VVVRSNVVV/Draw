using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMergeAnimator : MonoBehaviour
{
    public float radius;
    public float radialSpeed;
    public float angularSpeed;
    public static BallMergeAnimator Instance;
    [SerializeField] private List<BallScript> balls;
    private void Awake()
    {
        Instance = this;
    }
    public void Animate(List<BallScript> balls)
    {
        float time = balls[0].transform.position.magnitude / radialSpeed;
        foreach (var ball in balls)
        {
            AnimateBall(ball.transform, time);
        }
    }
    private void AnimateBall(Transform ball, float time)
    {
        Setup();
        float radius = ball.transform.position.magnitude;
        float xx = 0;
        DOTween.To(() => 0f, x =>
          {
              ball.RotateAround(transform.position, Vector3.forward, (x-xx)*angularSpeed*time);
              ball.position = ball.position.normalized * radius * (1-x);
              xx =x;
          }, 1f, time);

    }
    [ContextMenu("Animate")]
    public void Animate()
    {
        Animate(balls);
    }
    [ContextMenu("Setup")]
    private void Setup()
    {
        float angle = 0f;
        foreach (var ball in balls)
        {
            ball.transform.position = Quaternion.Euler(0, 0, angle) *Vector3.up * radius;
            angle += 120f;
        }

    }
}
