using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que sirve para eliminar hardcore.
/// </summary>
public class Constants : MonoBehaviour
{
    /// <summary>
    /// Nombres de Escenas.
    /// </summary>
    public string nameSceneMenu = "MainMenu";
    public string nameSceneNivel1 = "Nivel1";

    /// <summary>
    /// Nombres de Inputs.
    /// </summary>
    public string nameInputX = "Horizontal";
    public string nameInputZ = "Vertical";
    public string nameInputBtn1 = "Fire1";
    public string nameInputBtn2 = "Fire2";

    /// <summary>
    /// Tags.
    /// </summary>
    public string tagGraspable = "Graspable";

    /// </summary>
    /// Valores default del jugador.
    /// </summary>
    public float speedPlayer = 5f;
    public float limitDirectionMovePlayer = 0.1f;
    public float turnSmoothTimePlayer = 0.1f;

}
