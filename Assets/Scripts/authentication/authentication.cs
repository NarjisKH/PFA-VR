using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;


public class authentication : MonoBehaviour
{
    /*
    public delegate void LoginEvent(string name, string email, int status, string ip);
    
    public static LoginEvent OnLogin;
    
    public static string IP = "None"; 

[Header("Refrences")]
public GameObject Playerinfo;
public Animation LoginAnimation;
public Animation RegisterAnimation;
public Animation InfoAnimation; 

[Header("Ip Settings")]
public bool GetIpOnAwake = true;

[Header("UI")]
public Text Description = null; 
private static Text _Descrip = null; 

[Header("Scripts and their Refrences")]
public LoadingEffect Loading = null;
public static LoadingEffect LoadingCache = null;

public const string SavedUser = "UserName"; 

// Private values 
private bool InLogin = true; 
private bool ShowInfo = false; 
private SaveInfo saveInfo = null;

//private void Awake(){

    IP = string.Empty;
    if(Loading !=null){
        LoadingCache = Loading;
    }
    if(GetIpOnAwake){
        StartCoroutine(GetIP());
    }

    _Descrip = Description;
    OnLogin += onLogin;
    StartCoroutine(FadeOut());

        if (GameObject.Find(SavedUser) == null)
        {
            GameObject person = Instantiate(Playerinfo, Vector3.zero, Quaternion.identity) as GameObject;
            person.name = person.name.Replace("(Clone)", "");
            saveInfo = person.GetComponent<SaveInfo>();
        }
        else
        {
            saveInfo = null;
        }
}
    */
}
