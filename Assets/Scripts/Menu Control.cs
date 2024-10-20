using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
   public void Cambiodeescena()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();

    }
}
