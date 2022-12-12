using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComposantsInstantiateScript : MonoBehaviour
{
    public int limitObject;
    int nbrOfObject;
    public GameObject objet;
    public GameObject parent;
    void start(){
        nbrOfObject = 0;
    }
    public void ObjectInstantiateClick(){
        if(nbrOfObject < limitObject){
            ObjectInstantiate();
            nbrOfObject++;
        }
        else
        {
            Debug.Log("Max de l'objet atteint");
        }
    }
    public void ObjectInstantiate(){
        Instantiate(objet,parent.transform);
    }
}
