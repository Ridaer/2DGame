using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField m_loginPasswordInput = null;
    [SerializeField] private InputField m_loginUserNameInput = null;


    [Header("Register")]
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_password = null;
    [SerializeField] private InputField m_reEnterPassword = null;
    [SerializeField] private Text m_text = null;
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    private NetworkManager m_networkManager = null;
    
    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }
    
    public void SubmitLogin()
    {
        if(m_loginUserNameInput.text == "" || m_loginPasswordInput.text == "")
        {
            m_text.text = "Porfavor llena todos los campos";
            return;
        }
        m_text.text = "Procesando...";

        m_networkManager.CheckUser(m_loginUserNameInput.text, m_loginPasswordInput.text , delegate(Response response)
        {
             m_text.text = response.message;
             
             if(response.message == "Bienvenido")
             {
                SceneManager.LoadScene("MainMenu");
             }
         });
    }

    public void CerrarJuegoLogin()
    {
        Debug.Log("Salir..");
        Application.Quit();
    }


    
    public void SubmitRegister()
    {
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" || m_reEnterPassword.text == "")
        {
            m_text.text = "Porfavor llena todos los campos";
            return;
        }

       if(m_password.text == m_reEnterPassword.text)
       {
            m_text.text = "Procesando...";

            m_networkManager.CreateUser(m_userNameInput.text , m_emailInput.text, m_password.text , delegate(Response response)
            {
                m_text.text = response.message;
            });
       }
       else
       {
            m_text.text = "Contraseñas no son iguales pro favor verificar";
       }
    }


    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);

    }

}