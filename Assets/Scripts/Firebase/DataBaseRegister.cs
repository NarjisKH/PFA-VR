using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;
using Firebase.Extensions;
using System;

public class DataBaseRegister : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField confirmpassword;
    [SerializeField] private TMP_InputField nom;
    [SerializeField] private TMP_InputField prenom;
    [SerializeField] private TMP_Dropdown annee ;
    [SerializeField] private TMP_Dropdown classe ;
    [SerializeField] private GameObject infobox;
    [SerializeField] private TMP_Text infotext;

    private DatabaseReference dbReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void createUser()
    {
        string userID = Guid.NewGuid().ToString();
        if (username.text == null || password.text == null
            || username.text == "" || password.text == ""
        )
        {
            //Debug.Log("username and passeword can't be empty or null");
            info("username and passeword can't be empty or null");
            return;
        }
        if(password.text != confirmpassword.text){
            Debug.Log("passwords don't match");
            return;
        }
        var usersData = dbReference.Child("users").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            bool exist = false;
            if (task.IsFaulted)
            {
                // Handle the error...
                Debug.Log(task.Exception.Message);
                return;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                foreach (DataSnapshot user in snapshot.Children)
                {
                    IDictionary dictUser = (IDictionary)user.Value;
                    Debug.Log("" + dictUser["username"] + " - " + dictUser["pwd"]);
                    if (username.text == dictUser["username"].ToString())
                    {
                        info("username already taken or server error");
                        exist = true;
                        break;
                    }
                }

            }
            if (!exist)
            {
                User newUser = new User(username.text, password.text,
                nom.text, prenom.text,
                annee.options[annee.value].text, classe.options[classe.value].text);
                string json = JsonUtility.ToJson(newUser);
                dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
                inputreset();
                info(" user created ");
            }
        });

    }

    private void info(string msg)
    {
        infobox.SetActive(true);
        infotext.text = msg;
    }

    private void inputreset()
    {
        username.text = "";
        password.text = "";
        confirmpassword.text = "";
        nom.text = "";
        prenom.text = "";
        annee.value = 0;
        classe.value = 0;
    }

    /*
        private bool exists(String username)
        {
            bool check = false;
            var usersData = dbReference.Child("users").GetValueAsync().ContinueWithOnMainThread(task => {

                if (task.IsFaulted) {
                // Handle the error...
                Debug.Log (task.Exception.Message);
                check = true;
                }
                else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                // Do something with snapshot...
                foreach ( DataSnapshot user in snapshot.Children){
                            IDictionary dictUser = (IDictionary)user.Value;
                            Debug.Log ("" + dictUser["username"] + " - " + dictUser["pwd"]);
                            if(username == dictUser["username"].ToString()){
                                check = true;
                            }
                          }
                }
            });
            return check;
        }*/
}
