using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {

        // Rotate the camera around the pivot point based on mouse input if the "R" key is being held down.
        if (Input.GetKey(KeyCode.R))
        {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            float verticale = Input.GetAxis("Mouse Y") * rotateSpeed;
            float depth = Input.GetAxis("Mouse ScrollWheel") * rotateSpeed;
            transform.RotateAround(pivotPoint.position, transform.right, verticale);
            transform.RotateAround(pivotPoint.position, Vector3.up, horizontal);
            transform.RotateAround(pivotPoint.position, transform.forward, depth);
        }
        // Zoom in and out based on mouse scroll wheel input.
        float vertical = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - vertical, 10.0f, 60.0f);
    }
}
