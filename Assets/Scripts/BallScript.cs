using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 velocity
    {
        get => rb.velocity;
        set => rb.velocity = value;
    }
    //private void Update()
    //{
    //    transform.Translate(velocity*Time.deltaTime);
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var normal = collision.contacts[0].normal;
        var n = new Vector3(normal.x, normal.y, 0f);
        var tangent = Quaternion.Euler(0, 0, 90)*n;
        Debug.Log(tangent);
        if (Vector3.Dot(tangent, velocity) > 0)
        {
            velocity = tangent.normalized * velocity.magnitude;
        }
        else
        {
            velocity = -tangent.normalized * velocity.magnitude;
        }
    }
}



