using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
    private Vector3 dragStartPosition;

    private void OnMouseDown()
    {
        dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dragStartPosition.z = 0;
    }

    void OnMouseDrag()
    {

        // Update the position of the object based on the mouse position.
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // Keep the z position of the object
        transform.position = mousePos - dragStartPosition;
    }

    void OnMouseUp()
    {
        Snap();
    }
    void Snap()
    {
        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
                                            Mathf.Round(currentPos.y),
                                            Mathf.Round(currentPos.z));
    }
}
