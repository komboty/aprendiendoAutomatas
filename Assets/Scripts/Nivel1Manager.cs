using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script que controla el funcionamiento del Nivel 1.
/// </summary>
public class Nivel1Manager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Pantalla de GameOver.
    public Canvas canvasGameOver;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        canvasGameOver.gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(constants.nameSceneNivel1);
    }
}
