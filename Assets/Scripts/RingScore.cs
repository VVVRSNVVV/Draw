using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RingScore : MonoBehaviour
{
    [SerializeField] public ScoreManager _scoreManager;
    private int score;
    [SerializeField] Transform textOrigin;
    [SerializeField] TextSpawner _textSpawner;
   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (true)
        {
            score = collision.GetComponent<BallScript>().score;
            _scoreManager.scoring(score);
            _textSpawner.Spawn(textOrigin.position, (score* ComboHandler.Instance.combo).ToString());
            ComboHandler.Instance.Add();
        }
    }


}
