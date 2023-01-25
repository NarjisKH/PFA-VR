using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;
using Firebase.Extensions;
using System;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;

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
            Debug.Log("username and passeword can't be empty or null");
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
                        Debug.Log("username already taken or server error");
                        exist = true;
                        break;
                    }
                }

            }
            if (!exist)
            {
                User newUser = new User(username.text, password.text);
                string json = JsonUtility.ToJson(newUser);
                dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
                Debug.Log(" user created ");
            }
        });

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
