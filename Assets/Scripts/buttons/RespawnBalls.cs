using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnBalls : MonoBehaviour
{
    [SerializeField] BallCreator _ballCreator;
    [SerializeField] Button _respawnBalls;
    private void Awake()
    {
        _respawnBalls.onClick.AddListener(_ballCreator.RespawnAllCorute);
    }
}
