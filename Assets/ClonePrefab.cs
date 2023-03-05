using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClonePrefab : MonoBehaviour
{
    public GameObject prefab;
    public Vector2 offset;

    private Vector3 offsetV3;

    // Start is called before the first frame update
    void Start()
    {
        offsetV3 = new Vector3(offset.x, offset.y, 0);
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 spawnLocation = transform.position + offsetV3;
            bool occupied = false;
            // check if transform.position + offsetV3 is occupied
            // if so, spawn next to it
            Collider2D[] colliders;
            
            int depth = 0; // prevent infinite loop
            while (true && depth < 10)
            {
                colliders = Physics2D.OverlapBoxAll(spawnLocation + new Vector2(0.5f,0.5f), new Vector2(0.5f, 0.5f), 0);
                occupied = false;
                foreach (Collider2D collider in colliders)
                {
                    // make sure it doesn't count itself
                    if (collider.gameObject != gameObject && collider.gameObject.CompareTag("Block"))
                    {
                        occupied = true;
                        break;
                    }
                }
                if (!occupied)
                {
                    break;
                    
                }

                spawnLocation.x += 1;
                depth++;
            }
            if (depth < 10)
            {
                Instantiate(prefab, spawnLocation, transform.rotation);
            }
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
