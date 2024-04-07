using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que sirve para eliminar hardcore.
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
    public string nameGetAxisX = "Horizontal";
    public string nameGetAxisZ = "Vertical";

    /// </summary>
    /// Valores default del jugador.
    /// </summary>
    public float speedPlayer = 5f;
    public float limitDirectionMovePlayer = 0.1f;
    public float turnSmoothTimePlayer = 0.1f;
    //public float turnSmoothVelocityPlayer = 0f;

}
