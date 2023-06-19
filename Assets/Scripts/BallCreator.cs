using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    public float ballSpeed = 2f;
    public float spawnRate = .5f;
    public GameObject objectPrefab;
    [SerializeField] public Transform spawnPosition;

   List<GameObject> balls= new List<GameObject>();
    public void SpawnObject()
    {
        var ball = Instantiate(objectPrefab, spawnPosition.position, Quaternion.identity);
        ball.GetComponent<BallScript>().Init(this);
        Respawn(ball);
        balls.Add(ball);
    }
    public IEnumerator RespawnAll()
        {
        foreach (var ball in balls)
        { 
        ball.SetActive(false);
        }
        foreach (var ball in balls)
        {
            yield return new WaitForSeconds(0.25f);
            ball.SetActive(true);
            Respawn(ball);
           
        }
    }
    public void RespawnAllCorute()
    {
        Debug.Log("respawn all");
        StartCoroutine(RespawnAll());

    }
    public void Respawn(GameObject ball)
    {
        ball.transform.position = spawnPosition.position;
        ball.transform.rotation = Quaternion.identity;
        var rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left*ballSpeed;
    }
}
