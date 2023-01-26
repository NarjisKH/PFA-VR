using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject logincanvas;
    [SerializeField] private GameObject registercanva;

    void goToLoginScreen()
    {
        //SceneManager.LoadScene("Login");
        registercanva.SetActive(false);
        logincanvas.SetActive(true);
    }
    void goToRegisterScreen()
    {
        //SceneManager.LoadScene("Login");
        registercanva.SetActive(true);
        logincanvas.SetActive(false);
    }
}
