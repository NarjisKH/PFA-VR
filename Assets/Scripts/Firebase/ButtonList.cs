using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
//using Firebase.Unity.Editor;
using System.Collections.Generic;
using Firebase.Extensions;
using System.Collections;
using TMPro;

public class ButtonList : MonoBehaviour
{
    
    [SerializeField] private GameObject buttonPrefab; // Prefab for the button that will be generated
    private DatabaseReference databaseRef; // Reference to the Firebase Realtime Database

    void Start()
    {
        // Initialize Firebase Realtime Database
        databaseRef = FirebaseDatabase.DefaultInstance.RootReference;

        // Call the function to generate the buttons
        GenerateButtonList();
    }

    void GenerateButtonList()
    {
        Debug.Log("Generating ...");
        // Retrieve the data from Firebase Realtime Database
        var usersData = databaseRef.Child("salle").GetValueAsync().ContinueWithOnMainThread( task => {
            if (task.IsFaulted) {
                Debug.Log(task.Exception.Message);
            }
            else if (task.IsCompleted) {
                // Retrieve the data snapshot
                DataSnapshot snapshot = task.Result;

                // Create a list to hold the scene data
                //List<IDictionary> sceneList = new List<IDictionary>();
                Debug.Log(snapshot.ChildrenCount);
                // Loop through each child node in the "scenes" node
                foreach (DataSnapshot childSnapshot in snapshot.Children) {
                    Debug.Log(snapshot.ChildrenCount);
                    // Convert the child node data to a dictionary
                    IDictionary sceneData = (IDictionary)childSnapshot.Value;
                    GenerateBtn(sceneData);
                    // Add the dictionary to the scene list
                    //sceneList.Add(sceneData);
                }
                
            }
        });
    }
    void GenerateBtn(IDictionary sceneData){
        // Instantiate the button prefab
                    /*Vector3 pos = new Vector3(transform.position.x,
                    transform.position.y + 60,
                    transform.position.z
                    );*/
                    GameObject newButton = Instantiate(buttonPrefab, transform);

                    // Get the button component
                    Button button = newButton.GetComponent<Button>();

                    // Set the button text to the scene name
                    button.GetComponentInChildren<TextMeshProUGUI>().text = sceneData["titre"].ToString();
/*
                    // Add an onclick listener to the button
                    button.onClick.AddListener(() => {
                        // Load the scene when the button is clicked
                        string sceneName = sceneData["scene"].ToString();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                    });*/
    }
}
