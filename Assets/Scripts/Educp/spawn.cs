using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] BallCreator creator;
    // Start is called before the first frame update
    void Start()
    {
        creator.SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
