using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que sirve para poner un objeto en una plataforma.
/// </summary>
public class PlatformPutObject : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Punto donde se pondra el objeto.
    public GameObject floorPoint;
    // Area de agarre del jugador.
    public GameObject gripPlayer;
    // Modelo 3D de plataforma.
    public GameObject platformModel;
    // Material por defecto de la plataforma.
    public Material materialDeafult;
    // Objeto puesto en la plataforma.
    public GameObject symbolPost = null;

    private void OnTriggerStay(Collider other)
    {
        // Si se acerca un symbolo.
        if (other.gameObject.CompareTag(constants.tagSymbol))
        {            
            // Si se oprimio el Boton 3 y no se tiene un Simbolo puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn3) && symbolPost == null)
            {
                // Se pone el symbolo en la plataforma.
                PutSymbol(other);
            }
        }

        // Si se acerca la zona de agarre del jugador.
        if (other.gameObject.Equals(gripPlayer))
        {
            //Debug.LogWarning("Se acerca el jugador");            
            // Si se oprimio el Boton 1 y se tiene un symbolo puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn1) && symbolPost != null)
            {
                // Si el jugador tiene agarrado el mismo simbolo que esta puesto en la plataforma.
                if (gripPlayer.GetComponent<PlayerGrapObject>().grabbedObject == symbolPost)
                {
                    // Se quita el simbolo puesto en la plataforma.
                    QuitSymbol();
                }
            }
        }
    }

    /// <summary>
    /// Pone un simbolo en la plataforma.
    /// </summary>
    /// <param name="symbol">Simbolo a poner en la plataforma</param>
    private void PutSymbol(Collider symbol)
    {
        //Debug.LogWarning("Poner simbolo en " + modelPlatform.name);

        // Se quita el simbolo del Script del jugador.
        gripPlayer.GetComponent<PlayerGrapObject>().grabbedObject = null;

        // El simbolo se posiciona en la plataforma.
        symbol.transform.position = floorPoint.transform.position;
        symbol.gameObject.transform.SetParent(floorPoint.transform);

        // Se pone el material que tiene el simbolo en la plataforma.
        platformModel.GetComponent<MeshRenderer>().material = symbol.gameObject
            .GetComponent<MeshRenderer>().material;

        // Se asigna el simbolo al Script.
        symbolPost = symbol.gameObject;
    }

    /// <summary>
    /// Quita el simbolo puesto en la plataforma.
    /// </summary>
    private void QuitSymbol()
    {
        //Debug.LogWarning("Quitar simbolo de " + modelPlatform.name);

        // Se pone el material por defetco de la plataforma.
        platformModel.GetComponent<MeshRenderer>().material = materialDeafult;

        // Se quita el simbolo del Script.
        symbolPost = null;
    }
}
