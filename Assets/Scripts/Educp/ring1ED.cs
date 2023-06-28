using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring1ED : MonoBehaviour
{
    public bool ready = false;
    private int counter = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (true)
        {
            counter++;
        }
    }
    private void Update()
    {
        if (counter >= 2)
        { ready = true; }
    }
}

