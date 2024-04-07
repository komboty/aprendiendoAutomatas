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
    // Objeto puesto en la plataforma.
    public GameObject putObject = null;
    
    private void OnTriggerStay(Collider other)
    {
        // Si se acerca un objeto agarrable.
        if (other.gameObject.CompareTag(constants.tagGraspable))
        {            
            // Si se oprimio el Boton 3 y no se tiene un objeto puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn3) && putObject == null)
            {
                Debug.LogWarning("Poner Objeto en " + this.transform.parent.name);

                // Se quita el objeto agarrable del Script del jugador.
                grip.GetComponent<PlayerGrapObject>().grabbedObject = null;

                // El objeto agarrable se posiciona en la plataforma.
                other.transform.position = putPoint.transform.position;
                other.gameObject.transform.SetParent(putPoint.transform);

                // Se asigna el objeto agarrable al Script.
                putObject = other.gameObject;
            }
        }

        // Si se acerca la zona de agarre del jugador.
        if (other.gameObject.Equals(grip))
        {
            //Debug.LogWarning("Se acerca el jugador");            
            // Si se oprimio el Boton 1 y se tiene un objeto puesto en la plataforma.
            if (Input.GetButton(constants.nameInputBtn1) && putObject != null)
            {
                /*
                Debug.LogWarning("Quitar Objeto de " + this.transform.parent.name);

                // Se quita el objeto puesto en la plataforma del Script.
                putObject = null;
                */

                //Invoke(nameof(DeleteRefPutObject), 3);                

                // Si el jugador tiene agarro el mismo objeto de la plataforma.
                if (grip.GetComponent<PlayerGrapObject>().grabbedObject == putObject)
                {

                    Debug.LogWarning("Quitar Objeto de " + this.transform.parent.name);

                    // Se quita el objeto puesto en la plataforma del Script.
                    putObject = null;
                }
            }
        }
    }

    /*
    private void DeleteRefPutObject()
    {
        Debug.LogWarning("Quitar Objeto de " + this.transform.parent.name);

        // Si el jugador tiene agarro el mismo objeto de la plataforma.
        if (grip.GetComponent<PlayerGrapObject>().grabbedObject == putObject)
        {
            // Se quita el objeto puesto en la plataforma del Script.
            putObject = null;
        }   
    }
    */
}
