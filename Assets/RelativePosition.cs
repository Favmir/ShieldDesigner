using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativePosition : MonoBehaviour
{
    public SnapToGrid start;
    public SnapToGrid end;
    public SnapToGrid origin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin.transform.position + end.transform.position - start.transform.position;
        transform.rotation = end.transform.rotation;
    }
}
