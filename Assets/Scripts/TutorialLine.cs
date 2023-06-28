using System;
using UnityEngine;
using UnityEngine.UI;

public class TutorialLine : MonoBehaviour
{
    public static event Action OnDrawn;
    [SerializeField] private Line line;
   
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
