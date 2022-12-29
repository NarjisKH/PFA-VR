using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    void OnMouseDown()
    {
        // The game object has been selected.
        // You can add code here to start rotating the object.
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
