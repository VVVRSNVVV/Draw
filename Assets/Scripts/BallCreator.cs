using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    public float ballSpeed = 2f;
    public float spawnRate = .5f;
    public GameObject objectPrefab;
    public List<BallScript> ballPrefabs;
    [SerializeField] public Transform spawnPosition;

    public List<GameObject> balls = new List<GameObject>();
    public void SpawnObject()
    {
        SpawnObject(objectPrefab);
    }
    public void SpawnObject(GameObject prefab)
    {
        var ball = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
        ball.GetComponent<BallScript>().Init(this);
        Respawn(ball);
        balls.Add(ball);
    }
    public void SpawnObject(int ballType)
    {
        Debug.Log(ballType);
        SpawnObject(ballPrefabs.First(x => x.ballType == ballType).gameObject);

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
