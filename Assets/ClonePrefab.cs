using System.Collections;
using System.Collections.Generic;
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
            Instantiate(prefab, transform.position + offsetV3, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
