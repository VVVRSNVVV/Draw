using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class BallMergeAnimator : MonoBehaviour
{
    public float setupTime;
    public float mainAnimTime;
    public float radius;
    public float radialSpeed;
    public float angularSpeed;
    public static BallMergeAnimator Instance;
    [SerializeField] private List<BallScript> balls;
    public Transform[] positions;
    public AnimationCurve scaleCurve;
    private void Awake()
    {
        Instance = this;
    }
    public void Animate(List<BallScript> balls)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            var ball = balls[i];
            AnimateBall(ball.transform, mainAnimTime, GetPosition(i));
        }
    }
    private void AnimateBall(Transform ball, float time, Vector3 pos)
    {
        float xx = 0;

        Sequence sequence = DOTween.Sequence();
        Tween tween = ball.DOMove(pos, setupTime);
        sequence.Append(tween);
        float radius = pos.magnitude;

        tween = DOTween.To(() => 0f, x =>
          {
              ball.RotateAround(transform.position, Vector3.forward, (x-xx)*angularSpeed*time);
              ball.position = ball.position.normalized * radius * (1-x);
              ball.localScale = Vector3.one* scaleCurve.Evaluate(x);
              xx =x;
          }, 1f, time);
        sequence.Append(tween);
        sequence.Play();

    }

    [ContextMenu("Animate")]
    public void Animate()
    {
        Animate(balls);
    }
    [ContextMenu("Setup")]
    private void Setup()
    {
        int ballIndex = 0;
        foreach (var ball in balls)
        {
            ball.transform.position = GetPosition(ballIndex);
            ballIndex++;
        }

    }
    private Vector3 GetPosition(int ballindex)
    {
        return positions[ballindex].position;
    }
}
