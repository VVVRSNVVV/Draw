using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringED : MonoBehaviour
{
    [SerializeField] private RindEDHandler handler;
    public bool ready { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ready) return;
        if (!IsBall(collision)) return;
        ready = true;
        handler.Check();
    }
    private bool IsBall(Collider2D collision)
    {
        return true;
    }
    public void reset() => ready = false;
}

