using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
    public Constants constants;

    public void OnPlay()
    {
        SceneManager.LoadScene(constants.nameSceneNivel1);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
