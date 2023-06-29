using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SimpleBallCreator : MonoBehaviour
{
    public float ballSpeed = 2f;
    public float spawnRate = .5f;
    public GameObject objectPrefab;
    public List<BallScript> ballPrefabs;
    [SerializeField] public Transform spawnPosition;
    [SerializeField] private Pipe pipe;
    [SerializeField] Image pen;
    [SerializeField] private RindEDHandler rindEDHandler;

    public event Action OnBallSpawn;

    public List<GameObject> balls = new List<GameObject>();
    private void Awake()
    {
        TutorialLine.OnDrawn += SpawnObject;
        TutorialLine.OnDrawn += rindEDHandler.reset;
        //
    }
    public void SpawnObject()
    {
        SpawnObject(objectPrefab);
        pen.enabled = false;
        OnBallSpawn?.Invoke();
    }
    public void SpawnObject(GameObject prefab)
    {
        var ball = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
        //ball.GetComponent<BallScript>().Init(this);
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
        StartCoroutine(RespawnAll());

    }
    public void Respawn(GameObject ball)
    {
        var ballComp = ball.GetComponent<BallScript>();
        ballComp.Enable();
        var rb = ball.GetComponent<Rigidbody2D>();
        ball.GetComponent<Animator>().enabled = false;
        rb.velocity = Vector2.left * ballSpeed;
        ball.transform.position = spawnPosition.position;

    }
}
