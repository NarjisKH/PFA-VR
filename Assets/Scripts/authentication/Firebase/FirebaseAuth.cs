using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FirebaseAuth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI email;
    [SerializeField] private TextMeshProUGUI password;
    [SerializeField] private TextMeshProUGUI emailR;
    [SerializeField] private TextMeshProUGUI pwdR;
    
    
    [SerializeField] private GameObject logincanvas;
    [SerializeField] private GameObject registerCanva;
    
    [SerializeField] private Button loginButton;
    [SerializeField] private Button registerButton;

    [SerializeField] private Button goToLoginButton;
    [SerializeField] private Button goToRegisterButton;
    

    private Firebase.Auth.FirebaseUser user;
    private Firebase.Auth.FirebaseAuth auth;
    void Start()
    {
        InitializeFirebase();
        user =  Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser;
    }

    void goToLogin()
    {
        //SceneManager.LoadScene("Login");
        registerCanva.SetActive(false);
        logincanvas.SetActive(true);
    }
    void moveToRegister()
    {
        //SceneManager.LoadScene("Register");
        logincanvas.SetActive(false);
        registerCanva.SetActive(true);
    }
    void loadScreen()
    {
        SceneManager.LoadScene("ExperimentScene");
    }

    void InitializeFirebase() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        
    if (auth.CurrentUser != user) {
        bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
        if (!signedIn && user != null) {
        Debug.Log("Signed out " + user.UserId);
        }
        user = auth.CurrentUser;
        if (signedIn) {
        Debug.Log("Signed in " + user.UserId);
        /*displayName = user.DisplayName ?? "";
        emailAddress = user.Email ?? "";
        photoUrl = user.PhotoUrl ?? "";*/
        }
    }
    }

    void OnDestroy() {
    auth.StateChanged -= AuthStateChanged;
    auth = null;
    }

    //create user with firebase auth
    void userSignUp(){
        auth.CreateUserWithEmailAndPasswordAsync(emailR.text, pwdR.text).
        ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        // Firebase user has been created.
        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });
        goToLogin();
    }

    void userSignIn(){
        auth.SignInWithEmailAndPasswordAsync(email.text, password.text).
        ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });
    }
}
