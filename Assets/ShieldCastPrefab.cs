using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCastPrefab : MonoBehaviour
{
    public GameObject ignore;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the ShieldCastPrefab is colliding with a specific tag
        if (collision.gameObject != ignore)// && collision.gameObject.CompareTag("Block"))
        {
            // Change color to red
            gameObject.GetComponent<LineRenderer>().startColor = Color.red;
            gameObject.GetComponent<LineRenderer>().endColor = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the ShieldCastPrefab has stopped colliding with the specific tag
        if (collision.gameObject != ignore)
        {

            gameObject.GetComponent<LineRenderer>().startColor = Color.blue;
            gameObject.GetComponent<LineRenderer>().endColor = Color.blue;
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
