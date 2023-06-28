using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{

    public GameObject linePrefab;

    Line activeLine;
    public List<Line> lines = new List<Line>();
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (Line line in lines)
            {
                if (line.Overlaps(ray))
                {
                    Destroy(line.gameObject);
                    return;
                }

            }
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
            lines.Add(activeLine);
                var _line = activeLine;
            activeLine.OnDestroyCallback += () =>
            {
                Debug.Log("activeLine.OnDestroyCallback(), line: " + _line.name);
                lines.Remove(_line);

            };
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }

    }


}
