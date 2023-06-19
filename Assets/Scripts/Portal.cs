using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isOrange;
    public float distance = 0.2f;

     void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("orange portal").GetComponent<Transform>();

        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("blue portal").GetComponent<Transform>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position)>distance) 
        {
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
           var ab = other.transform.GetComponent<Rigidbody2D>();
            ab.velocity = destination.right*ab.velocity.magnitude;
        }
    }




}
