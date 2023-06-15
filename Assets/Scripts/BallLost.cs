using System;
using UnityEngine;

public class BallLost : MonoBehaviour
{
    public event Action OnLost;
    public float MaxMagnitude = 30;
    private void Update()
    {
        if (transform.position.magnitude > MaxMagnitude)
        {
            OnLost?.Invoke();
        }
    }
}
