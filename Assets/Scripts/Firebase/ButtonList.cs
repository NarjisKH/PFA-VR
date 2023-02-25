using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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


    void Awake()
    {
        // Initialize Firebase Realtime Database
        databaseRef = FirebaseDatabase.DefaultInstance.GetReference("salles");
        // Listen for changes in the "scenes" node
        databaseRef.ValueChanged += GenerateButtonList;
    }

    void GenerateButtonList(object sender, ValueChangedEventArgs args)
    {

        Debug.Log("Generating ...");
        Debug.Log(args.Snapshot.ChildrenCount);
        // Retrieve the data from Firebase Realtime Database
         if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
                // Retrieve the data snapshot
                DataSnapshot snapshot =  args.Snapshot;

                int i =1;
                // Loop through each child node in the "scenes" node
                foreach (DataSnapshot childSnapshot in snapshot.Children) {
                    // Convert the child node data to a dictionary
                    IDictionary sceneData = (IDictionary)childSnapshot.Value;

                    GenerateBtn(sceneData,i);
                    i++;
                }
        Debug.Log("Done.");
    }
    void GenerateBtn(IDictionary sceneData, int i){
        // Instantiate the button prefab
                    Vector3 pos = new Vector3(transform.position.x,
                    transform.position.y - 80*i,
                    transform.position.z
                    );
                    GameObject newButton = Instantiate(buttonPrefab, pos,transform.rotation,transform);


                    // Get the button component
                    Button button = newButton.GetComponent<Button>();

                    // Set the button text to the scene name
                    button.GetComponentInChildren<TextMeshProUGUI>().text = sceneData["titre"].ToString();
                    button.GetComponent<SceneInformation>().SetInformation(sceneData);

                    // Add an onclick listener to the button
                    button.onClick.AddListener(() => {
                        // Load the scene when the button is clicked
                        string sceneName = sceneData["scene"].ToString();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                    });
    }
    
}
