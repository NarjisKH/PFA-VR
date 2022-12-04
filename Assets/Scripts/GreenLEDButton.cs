using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLEDButton : MonoBehaviour
{
    
    public GameObject objet;
    public GameObject parent;
    public void greenLedClick(){
        Instantiate(objet,parent.transform);
    }
}
