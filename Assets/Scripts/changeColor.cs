using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Behaviour halo=(Behaviour)GetComponent("Halo");
        halo.size=10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


/*
drag and drop
senarios
exercices division : beginner friendly then cercuit avec des emplacements specifiques
minimize the possibilities of manipulations by the user
corriger l'emplacement, find the right and wrong placements

res led generateur
fix their emplacement as first exp
associate each res with a number

fixated spots qnd changing component
a solution : tags en matrice

*/