using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotates : MonoBehaviour
{
    float rotationSpeed = 1f;

    void OnMouseDrag()
    {
        float Xaxisrotation = Input.GetAxis("Mouse X") * rotationSpeed;

        float Yaxisrotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.Rotate(Vector3.down, Xaxisrotation);
        transform.Rotate(Vector3.right, Yaxisrotation);
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
