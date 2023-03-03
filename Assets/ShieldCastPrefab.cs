using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCastPrefab : MonoBehaviour
{
    private bool isTouching;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the ShieldCastPrefab is colliding with a specific tag
        if (collision.gameObject.CompareTag("Block"))
        {
            // Set isTouching to true to indicate that the ShieldCastPrefab is touching the other object
            isTouching = true;
            // Change color to red
            gameObject.GetComponent<LineRenderer>().SetColors(Color.red,Color.red);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the ShieldCastPrefab has stopped colliding with the specific tag
        if (collision.gameObject.CompareTag("Block"))
        {
            // Set isTouching to false to indicate that the ShieldCastPrefab is no longer touching the other object
            isTouching = false;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
