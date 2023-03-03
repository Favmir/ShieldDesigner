using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CircleRaycast : MonoBehaviour
{

    public float radius = 13f;
    public int raySegments = 32;
    public float angle = 160f;
    public LayerMask obstacleLayer;
    
    private List<LineRenderer> lines;
    private Vector2 origin;
    private float startWidth;
    private float endWidth;
    private float angleRad;
    private float directionAngle;
    private Vector2 direction;

    private void Start()
    {
        lines = new List<LineRenderer>();
        origin = transform.position;

        startWidth = 0f;
        endWidth = Mathf.Sin(Mathf.Deg2Rad*(angle / raySegments / 2)) * radius * 2;
        angleRad = -Mathf.Deg2Rad * angle;


    }

    private void Update()
    {
        

        // draw raySegments number of lines
        for (int i = 0; i < raySegments; i++)
        {
            LineRenderer line = new LineRenderer();
            line.startWidth = startWidth;
            line.endWidth = endWidth;
            // calculate angle of each line
            directionAngle = -(angleRad / 2) + angleRad / raySegments * i;

            // calculate direction of each line
             direction = new Vector2(Mathf.Cos(directionAngle), Mathf.Sin(directionAngle));
            // draw line
            line.SetPosition(0, origin);
            line.SetPosition(1, origin + direction * radius);

            lines.Add(line);
            
        }
    }
}
