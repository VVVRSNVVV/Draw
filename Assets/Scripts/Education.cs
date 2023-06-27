using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Education : MonoBehaviour
{
    public AnimationClipPlayer[] data;
    private int _dataIndex;

    private void Start()
    {
        float delay = 0.05f;
        for (int i = 0; i < data.Length; i++)
        {
            Invoke("Play", delay);
            delay += data[i].duration;
        }
    }

    private void Play()
    {
        var info = data[_dataIndex];
        info.Play();
        _dataIndex++;

    }


}
