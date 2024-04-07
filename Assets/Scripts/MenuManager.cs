using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script que controla el funcionamiento del Menu.
/// </summary>
public class MenuManager : MonoBehaviour 
{
    // Constantes del juego.
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
