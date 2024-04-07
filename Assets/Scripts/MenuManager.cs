using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que controla el funcionamiento del Menu.
/// </summary>
public class MenuManager : MonoBehaviour 
{
    // Variable con constantes de todo el juego.
    public Constants constants;

    /// <summary>
    /// Inicia el juego.
    /// </summary>
    public void OnPlay()
    {
        SceneManager.LoadScene(constants.nameSceneNivel1);
    }

    /// <summary>
    /// Finaliza el juego.
    /// </summary>
    public void OnExit()
    {
        Application.Quit();
    }
}
