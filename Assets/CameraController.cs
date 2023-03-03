using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float panSpeed = 1f;

    private float distance = 10f;
    private Vector3 lastMousePosition;

    private void Start()
    {
        lastMousePosition = Input.mousePosition;
        
    }

    private void Update()
    {
        // Zoom in/out with scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * scrollSpeed;
        distance = Mathf.Clamp(distance, 1f, 20f);

        //orthographic
        GetComponent<Camera>().orthographicSize = distance;

        // Pan camera with right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Translate(-delta.x * panSpeed, -delta.y * panSpeed, 0f);
            lastMousePosition = Input.mousePosition;
        }
    }
}
