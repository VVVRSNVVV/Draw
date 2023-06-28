using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;
    public EdgeCollider2D edgeColMouse;

    List<Vector2> points;
    public event Action OnDestroyCallback;
    private void OnDestroy()
    {
        OnDestroyCallback?.Invoke();
    }


    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        if (Vector2.Distance(points.Last(), mousePos) > .1f)
            SetPoint(mousePos);


    }
    public bool Overlaps(Vector2 point)
    {
        return edgeCol.OverlapPoint(point);
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {

            edgeCol.enabled = true;
            edgeCol.points = points.ToArray();
            edgeColMouse.enabled = true;
            edgeColMouse.points = points.ToArray();
        }
        else
        {
            edgeCol.enabled = false;
            edgeColMouse.enabled = false;
        }
    }

}