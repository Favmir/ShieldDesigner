using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    public Vector2 centerOffset;

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
        
        // if alt is pressed delete
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Destroy(gameObject);
        }
        // if control is pressed flip horizontally
        else if (Input.GetKey(KeyCode.LeftControl))
        {
                // flip the object horizontally
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.Translate(new Vector3(-transform.localScale.x*2 * centerOffset.x, 0, 0), transform);
        }
         else
        {
            isDragging = true;
        }
        
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // Keep the z position of the object
        if (isDragging)
        {
            // if alt is pressed delete
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Destroy(gameObject);
            }
            // if control is pressed flip horizontally
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                // flip the object horizontally
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.Translate(new Vector3(-transform.localScale.x * 2 * centerOffset.x, 0, 0), transform);
                dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                dragStartPosition.z = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                GameObject clone = Instantiate(gameObject, transform.position, transform.rotation);
                clone.GetComponent<SnapToGrid>().Snap();

            }
            // Right mouse button rotates gameObject 90 degrees
            // using mousePos as center
            else if (Input.GetMouseButtonDown(1))
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

        // get other object colliding with given dragCollider

        if (dragCollider != null)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(dragCollider.bounds.center, dragCollider.bounds.size - new Vector3(0.98f, 0.98f, 0.98f), 0);

            foreach (Collider2D collider in colliders)
            {
                if (collider != dragCollider && collider.gameObject.CompareTag("Block"))
                {
                    Destroy(collider.gameObject);
                }
            }

        }
       
        
    }

    private void Update()
    {

    }
    /*
    public Vector3 getCenter()
    {
        return transform.position + centerOffset.x * transform.forward;
    }

    public void moveCenterTo(Vector3 destination)
    {
        transform.position += destination - centerOffset.x * transform.forward;
    }

    */
}
