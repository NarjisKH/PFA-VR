using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropMobileScript : MonoBehaviour, IPointerDownHandler
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public float rotationSpeed = 50.0f;
    bool isDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        offset = transform.position - TouchWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
        isDown = true;
        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnDrag(PointerEventData eventData)
    {

        if (isDown)
        {
            float Xaxisrotation = eventData.delta.x * rotationSpeed * Time.deltaTime;
            float Yaxisrotation = eventData.delta.y * rotationSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(-Yaxisrotation, Xaxisrotation, 0));
            /*transform.Rotate(Vector3.down, Xaxisrotation);
            transform.Rotate(Vector3.right, Yaxisrotation);*/
        }
        else
        {
            transform.position = TouchWorldPosition() + offset;
        }
    }

    void OnEndDrag(PointerEventData eventData)
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = TouchWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }

    Vector3 TouchWorldPosition()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchScreenPos = touch.position;
            touchScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            return Camera.main.ScreenToWorldPoint(touchScreenPos);
        }
        return Vector3.zero;
    }
}
