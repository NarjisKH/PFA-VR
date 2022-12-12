using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceButton1 : MonoBehaviour
{
    
    public GameObject objet;
    public GameObject parent;
    public void resistanceClick(){
        Instantiate(objet,parent.transform);
    }
}
