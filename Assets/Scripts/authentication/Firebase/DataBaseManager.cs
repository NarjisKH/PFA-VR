using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;

public class DataBaseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI username;
    [SerializeField] private TextMeshProUGUI password;

    private DatabaseReference dbReference;
    // Start is called before the first frame update
    void Start()
    {
        // Get the root reference location of the database.
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    // Update is called once per frame
    public void createUser()
    {
        string userID = SystemInfo.deviceUniqueIdentifier;
        User newUser = new User(username.text, password.text);
        string json = JsonUtility.ToJson(newUser);
        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }
}
