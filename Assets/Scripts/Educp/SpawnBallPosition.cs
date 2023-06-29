using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallPosition : MonoBehaviour
{
  [SerializeField] SimpleBallCreator _creator;
    [SerializeField] RespawnerED _respawnED;


    private void Start()
    {
        _respawnED.OnBallDestroy += () => gameObject.SetActive(true);
        _creator.OnBallSpawn += () => gameObject.SetActive(false);
    }
}
