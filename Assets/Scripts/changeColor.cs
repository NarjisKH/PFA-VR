using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class changeColor : MonoBehaviour
{
    [SerializeField] private bool _isEnabled = true;
    [SerializeField] private bool _isNotEnabled = false;
    [SerializeField] private Color _color = Color.green;
    [SerializeField] private float _size = 10;


    public void Placed()
    {
        SerializedObject halo = new SerializedObject(GetComponent("Halo"));
        halo.FindProperty("m_Enabled").boolValue = _isEnabled;
        halo.FindProperty("m_Color").colorValue = _color;
        halo.FindProperty("m_Size").floatValue = _size;
        // if(collisionInfo.collider.name=="res1"){
        //     halo.FindProperty("m_Size").floatValue = 10;
        // }
        // if(collisionInfo.collider.name=="res2"){
        //     halo.FindProperty("m_Size").floatValue = 5;
        // }
        // else{
        //     notPlaced();
        // }
        halo.ApplyModifiedProperties();
    }

    public void notPlaced()
    {
        SerializedObject halo = new SerializedObject(GetComponent("Halo"));
        halo.FindProperty("m_Enabled").boolValue = _isNotEnabled;
        halo.ApplyModifiedProperties();
    }
}

// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         // Behaviour halo=(Behaviour)GetComponent("Halo");
//         // halo.size=10;
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }


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