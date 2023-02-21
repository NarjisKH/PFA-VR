﻿using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class DAHover : MonoBehaviour
{
    public string Posname = "0";
    private Color color;
    public TMP_Text textMsg;
    private void Start()
    {
        //textMsg = GetComponent<TextMeshProUGUI>();
        color = GetComponent<Renderer>().material.color;
        Posname = this.name.Substring(this.name.Length-1);
        textMsg=GameObject.FindGameObjectWithTag("indication").GetComponent<TMP_Text>();
    }
    void OnMouseOver ()
    {
        GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        textMsg.text ="hover sur le trou " + Posname;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = color;
        textMsg.text = "";
        Debug.Log("Mouse is no longer on GameObject.");
    }

}
