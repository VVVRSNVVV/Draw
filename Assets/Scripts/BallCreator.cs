using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    public float ballSpeed = 2f;
    public float spawnRate = .5f;
    public GameObject objectPrefab;
    [SerializeField] public Transform spawnPosition;
    

    public void SpawnObject()
    {
        var ball = Instantiate(objectPrefab, spawnPosition.position, Quaternion.identity);
        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left*ballSpeed;
    }
}
