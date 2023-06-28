using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLine : MonoBehaviour
{
    public static event Action OnDrawn;
    [SerializeField] private Line line;
   public static List<TutorialLine> lines = new List<TutorialLine>();
    private void Awake()
    {
        lines.Add(this);
    }
    private void OnDestroy()
    {
        lines.Remove(this);
    }
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(this);
            return;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(line.edgeCol.pointCount < 3)
            {
                Destroy(this);
                return;
            }
            OnDrawn?.Invoke();
           
        }
    }
}
