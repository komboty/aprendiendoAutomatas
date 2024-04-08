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
    public GameObject putPoint;
    // Area de agarre del jugador.
    public GameObject grip;
    // Modelo 3D de plataforma.
    public GameObject modelPlatform;
    // Material por defecto de la plataforma.
    public Material materialDeafult;
    // Objeto puesto en la plataforma.
    public GameObject putSymbol = null;

    private void OnTriggerStay(Collider other)
    {
        // Si se acerca un symbolo.
        if (other.gameObject.CompareTag(constants.tagSymbol))
        {            
            // Si se oprimio el Boton 3 y no se tiene un Simbolo puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn3) && putSymbol == null)
            {
                // Se pone el symbolo en la plataforma.
                PutSymbol(other);
            }
        }

        // Si se acerca la zona de agarre del jugador.
        if (other.gameObject.Equals(grip))
        {
            //Debug.LogWarning("Se acerca el jugador");            
            // Si se oprimio el Boton 1 y se tiene un symbolo puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn1) && putSymbol != null)
            {
                // Si el jugador tiene agarrado el mismo simbolo que esta puesto en la plataforma.
                if (grip.GetComponent<PlayerGrapObject>().grabbedObject == putSymbol)
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
        grip.GetComponent<PlayerGrapObject>().grabbedObject = null;

        // El simbolo se posiciona en la plataforma.
        symbol.transform.position = putPoint.transform.position;
        symbol.gameObject.transform.SetParent(putPoint.transform);

        // Se pone el material que tiene el simbolo en la plataforma.
        modelPlatform.GetComponent<MeshRenderer>().material = symbol.gameObject
            .GetComponent<MeshRenderer>().material;

        // Se asigna el simbolo al Script.
        putSymbol = symbol.gameObject;
    }

    /// <summary>
    /// Quita el simbolo puesto en la plataforma.
    /// </summary>
    private void QuitSymbol()
    {
        //Debug.LogWarning("Quitar simbolo de " + modelPlatform.name);

        // Se pone el material por defetco de la plataforma.
        modelPlatform.GetComponent<MeshRenderer>().material = materialDeafult;

        // Se quita el simbolo del Script.
        putSymbol = null;
    }
}
