using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;
using Firebase.Extensions;
using System;
using UnityEngine.SceneManagement;

public class DataBaseLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private GameObject infobox;
    [SerializeField] private TMP_Text infotext;

    private DatabaseReference dbReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void loginUser()
    {
        if (username.text == null || password.text == null
            || username.text == "" || password.text == ""
        )
        {
            //Debug.Log("username and passeword can't be empty or null");
            info("username and passeword can't be empty or null");
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
                    if (username.text == dictUser["username"].ToString()
                    && password.text == dictUser["pwd"].ToString())
                    {
                        info("welcome");
                        exist = true;
                        SceneManager.LoadScene("ExperimentScene");
                        break;
                    }
                }

            }
            if (!exist)
            {
                inputreset();
                info("username or passeword is incorrect");
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
    }
}
