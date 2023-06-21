using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Vector3 offset;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        InitPosition();
    }

    private void InitPosition()
    {
        var size = camera.orthographicSize;
        var aspectRatio = Screen.width / (float)Screen.height;
        var right = size * aspectRatio;
        transform.position = Vector3.right * right + offset;
    }
    private void Update()
    {
        InitPosition();
    }
}
