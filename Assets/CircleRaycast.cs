using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CircleRaycast : MonoBehaviour
{
    public float radius = 13f;
    public int raySegments = 64;
    public float angle = 160f;
    public LayerMask obstacleLayer;
    [SerializeField] private ShieldCastPrefab _linePrefab;

    private Vector3 origin;
    private float startWidth;
    private float endWidth;
    private float angleRad;
    private float directionAngle;
    private Vector3 direction;

    private void Start()
    {
        origin = transform.position;

        startWidth = 0f;
        endWidth = Mathf.Sin(Mathf.Deg2Rad * (angle / raySegments / 2)) * radius * 2;
        angleRad = -Mathf.Deg2Rad * angle;

        for (int i = 0; i < raySegments; i++)
        {
            var ray = Instantiate(_linePrefab, new Vector3(origin.x, origin.y, 0), Quaternion.identity);
            ray.transform.SetParent(transform);
            // set tile name as coordinate
            ray.name = $"ray{i}";

            // calculate angle of each line
            directionAngle = 0.5f*Mathf.PI - (angleRad / 2) + (i + 0.5f) * angleRad / raySegments;
            direction = new Vector3(Mathf.Cos(directionAngle), Mathf.Sin(directionAngle),0);
            ray.GetComponent<LineRenderer>().SetPosition(0, origin);
            ray.GetComponent<LineRenderer>().SetPosition(1, origin + (direction * radius));
            ray.GetComponent<LineRenderer>().endWidth = endWidth;

            
        }
    }

    private void Update()
    {
    }
}
