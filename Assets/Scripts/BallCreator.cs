using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField] private int ringsCount;
    public float ballSpeed = 2f;
    public float spawnRate = .5f;
    public GameObject objectPrefab;
    public List<BallScript> ballPrefabs;
    [SerializeField] public Transform spawnPosition;
    [SerializeField] private Pipe pipe;

    public List<GameObject> balls = new List<GameObject>();
    private void Awake()
    {
        BallRingCombo.comboTarget = ringsCount;
    }
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
        StartCoroutine(RespawnAll());

    }
    public void Respawn(GameObject ball)
    {
        var ballComp = ball.GetComponent<BallScript>();
        ballComp.Disable();
        if (pipe)
            ball.transform.parent = pipe.transform;
        ball.GetComponent<Animator>().enabled = true;
        ball.GetComponent<Animator>().SetTrigger("Spawn");
        ball.GetComponent<Rigidbody2D>().angularVelocity = 0;
        ball.transform.rotation = Quaternion.identity;
        DOVirtual.DelayedCall(1.2f, () =>
        {
            ballComp.Enable();
            ball.GetComponent<Animator>().enabled = false;
            var rb = ball.GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.left * ballSpeed;
        });
        //ball.transform.position = spawnPosition.position;

    }
}
