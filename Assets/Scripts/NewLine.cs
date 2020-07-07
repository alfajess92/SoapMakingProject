using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLine : MonoBehaviour
{
    LineRenderer line;
    public float startWidthOfLine = .02f, endWidthOfLine = .001f;
    public Material lineMaterial;
    public List<Transform> linePositions = new List<Transform>();
    int numberOfCorners;


    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();
        line.widthMultiplier = startWidthOfLine;
        line.positionCount = linePositions.Count;
        line.startWidth = startWidthOfLine;
        line.endWidth = endWidthOfLine;
        line.useWorldSpace = true;
        line.material = lineMaterial;
        for (int i = 0; i < linePositions.Count; i++)
        {
            line.SetPosition(i, linePositions[i].position);
        }
    }
}