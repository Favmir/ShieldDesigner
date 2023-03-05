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
        if (Input.GetMouseButtonDown(2))
        {
            // Record the mouse position when the button is first pressed.
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(2))
        {
            // Calculate the distance the mouse has moved since the button was pressed.
            Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - lastMousePosition;

            // Move the camera in the opposite direction of the mouse movement.
            transform.position -= delta * panSpeed;

            // Update the last mouse position.
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
