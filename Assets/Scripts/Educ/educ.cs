using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class educ : MonoBehaviour
{

    [SerializeField] BallCreator creator1;
    [SerializeField] BallCreator creator2;
    // Start is called before the first frame update
    void Start()
    {
        creator1.SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
