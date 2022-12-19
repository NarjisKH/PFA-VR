using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public GameObject objetDetecter;
    void OnTriggerEnter(Collider other) {  
        print("Another object has entered the trigger");
        ( (Behaviour)other.GetComponent("Halo")).enabled =true;  
    }
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        print("Exited");  
    } 
}
