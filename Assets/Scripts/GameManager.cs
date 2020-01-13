using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Se encarga de controlar control de flujo del juego
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Instancia estatica del GameManager
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Devuelve la instancia del GameManager que esta ejecuntando
    /// </summary>
    /// <returns></returns>
    public static GameManager GetInstance()
    {
        if(instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }

    /// <summary>
    /// Funcion que se ejecuta en el start
    /// </summary>
    public void Start()
    {
        DontDestroyOnLoad(this); //No destruimos nunca el objeto del GameManager
        
        if(GameManager.instance == null)
        {
            GameManager.instance = this; // Guardamos esta instancia como la actual del GameManager
        }

    }


    /// <summary>
    /// Inicia la escena principal
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
