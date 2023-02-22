using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public float rotationSpeed = 50.0f;
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    void OnMouseDrag()
    {
        if (Input.GetKey(KeyCode.E))
        {
            float Xaxisrotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float Yaxisrotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.Rotate(Vector3.down, Xaxisrotation);
            transform.Rotate(Vector3.right, Yaxisrotation);
        }
        else
        {
            transform.position = MouseWorldPosition() + offset;
        }
    }
    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if(hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }
 
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
