using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRingCombo : MonoBehaviour
{
    public static int comboTarget;
    private int combo;
    private HashSet<GameObject> rings = new HashSet<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsRing(collision)) return;
        if(rings.Contains(collision.gameObject)) return;
        Debug.Log("BallRingCombo");
        rings.Add(collision.gameObject);
        combo++;
        if(combo == comboTarget)
        {
            ComboHandler.Instance.Add();
            reset();
        }

    }
    private bool IsRing(Collider2D collision)
    {
        if (collision.tag == "ring") { return true; }

        else { return false; }
    }
    public void reset()
    {
        combo = 0; 
        rings.Clear();
    }
}
