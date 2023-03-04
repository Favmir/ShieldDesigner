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
    public GameObject ignore;
    [SerializeField] private ShieldCastPrefab _linePrefab;

    private Vector3 shieldPos;
    private float startWidth;
    private float endWidth;
    private float angleRad;
    private float directionAngle;
    private Vector3 direction;
    private Vector3 previousPosition;
    private float previousZRotation;

    private void Start()
    {
        previousPosition = transform.position;
        shieldPos = gameObject.GetComponentInParent<Transform>().position;

        startWidth = 0f;
        endWidth = Mathf.Sin(Mathf.Deg2Rad * (angle / raySegments / 2)) * radius * 2;
        angleRad = -Mathf.Deg2Rad * angle;

        for (int i = 0; i < raySegments; i++)
        {
            ShieldCastPrefab ray = Instantiate(_linePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            ray.transform.SetParent(transform);
            ray.name = $"ray{i}";

            // calculate angle of each line
            directionAngle = 0.5f*Mathf.PI - (angleRad / 2) + (i + 0.5f) * angleRad / raySegments;
            direction = new Vector3(Mathf.Cos(directionAngle), Mathf.Sin(directionAngle),0);

            LineRenderer rayLine = ray.GetComponent<LineRenderer>();
            rayLine.SetPosition(0, new Vector3(0,0,0));
            rayLine.SetPosition(1, (direction * radius));
            rayLine.startWidth = startWidth;
            rayLine.endWidth = endWidth;
            
            rayLine.startColor = Color.blue;
            rayLine.endColor = Color.blue;

        }
    }

    private void Update()
    {   
        foreach (ShieldCastPrefab ray in gameObject.GetComponentsInChildren<ShieldCastPrefab>())
        {
            LineRenderer rayLine = ray.GetComponent<LineRenderer>();
            
            // get index 0 and 1 points in LineRenderer
            RaycastHit2D hitInfo = Physics2D.Linecast(transform.TransformPoint(rayLine.GetPosition(0)), transform.TransformPoint(rayLine.GetPosition(1)));
            
            // Check if the collider of the hit object is not a trigger.
            if (hitInfo.collider != null && hitInfo.collider.gameObject != ignore)
            {
                rayLine.startColor = Color.red;
                rayLine.endColor = Color.red;
            }
            else
            {
                rayLine.startColor = Color.blue;
                rayLine.endColor = Color.blue;
            }
        }

        previousPosition = transform.position;
        previousZRotation = transform.rotation.z;
    }
}
