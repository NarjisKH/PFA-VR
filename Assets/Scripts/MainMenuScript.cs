using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Entrer(){
         SceneManager.LoadScene("ExperimentScene");
    } 
    public void Options(){

    }
    public void Quitter(){
        Application.Quit();
    }
}
