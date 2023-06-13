using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] public int score;
    private float maxSpeed;
    


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
        var normal = collision.contacts[0].normal;
        var n = new Vector3(normal.x, normal.y, 0f);
        var tangent = Quaternion.Euler(0, 0, 90)*n;
        Debug.Log(tangent);
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
        if (other.CompareTag("SpeedZone")) 
        {

            speed = maxSpeed;
        }
    }
}



