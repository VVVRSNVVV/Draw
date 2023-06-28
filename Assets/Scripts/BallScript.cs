using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] public int score;
    private float maxSpeed;
    [SerializeField] private BallLost ballLost;

    public int ballType;




    public void Init(BallCreator ballCreator)
    {
        ballLost.OnLost += () =>
        {
            ballCreator.Respawn(ballLost.gameObject);
        };
    }
    public void Init(SimpleBallCreator ballCreator)
    {
        ballLost.OnLost += () =>
        {
            ballCreator.Respawn(ballLost.gameObject);
        };
    }
    public void Disable()
    {
        rb.isKinematic = true;
    }
    public void Enable()
    {
        rb.isKinematic = false;
        speed = maxSpeed/2;
    }


    public Vector3 velocity

    {
        get => rb.velocity;
        set => rb.velocity = value;
    }
    //private void Update()
    //{
    //    transform.Translate(velocity*Time.deltaTime);
    //}

    //private void Awake()
    //{
    //    speed = rb.velocity.magnitude;
    //    Debug.Log(speed);
    //}
    private void Awake()
    {
        maxSpeed = 2 * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision:", collision.collider);
        var normal = collision.contacts[0].normal;
        var n = new Vector3(normal.x, normal.y, 0f);
        var tangent = Quaternion.Euler(0, 0, 90)*n;

        if (Vector3.Dot(tangent, velocity) > 0)
        {
            velocity = tangent.normalized * speed;
        }
        else
        {
            velocity = -tangent.normalized * speed;
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpeedZone"))
        {
            speed = maxSpeed;
            velocity = speed * velocity.normalized;
            Debug.Log(maxSpeed);
        }
    }
}




