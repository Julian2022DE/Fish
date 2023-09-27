using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_Scene : MonoBehaviour
{
    public void Reseteo()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Salir()
    {
        Application.Quit();
    }

}
