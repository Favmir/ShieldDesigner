using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private bool isDragging;
    private Vector3 dragStartPosition;
    private Collider2D dragCollider;

    private void Start()
    {
        isDragging = false;
        dragCollider = gameObject.GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dragStartPosition.z = 0;
        
        isDragging = true;


    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // Keep the z position of the object
        if (isDragging)
        {
            // Right mouse button rotates gameObject 90 degrees
            // using mousePos as center
            if (Input.GetMouseButtonDown(1))
            {
                Vector3 offset = mousePos - transform.position;
                transform.Rotate(0, 0, -90);
                dragStartPosition = dragStartPosition - offset + Quaternion.Euler(0,0,-90) * offset;
            }
            
            // Update the position of the object based on the mouse position.
            transform.position = mousePos - dragStartPosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        Snap();
    }
    void Snap()
    {
        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
                                            Mathf.Round(currentPos.y),
                                            Mathf.Round(currentPos.z));

        // if there is another object in the same position delete it
        var colliders = Physics2D.OverlapBoxAll(transform.position, dragCollider.bounds.size, 0);
    }

    private void Update()
    {

    }
}
