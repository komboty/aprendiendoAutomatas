using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Script que inicia el automata.
/// </summary>
public class StartAutomata : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Area de agarre del jugador.
    public GameObject gripPlayer;
    // Plataformas a validar.
    public List<PlatformPutObject> plataforms;

    private void OnTriggerStay(Collider other)
    {
        // Si se acerca la zona de agarre del jugador.
        if (other.gameObject.Equals(gripPlayer))
        {            
            // Si se oprimio el Boton 3.
            if (Input.GetButton(constants.nameInputBtn3))
            {
                //Debug.Log("Boton Click");

                // Se Verifica que todas las plataformas tengan un simbolo.
                foreach (PlatformPutObject plataform in plataforms)
                {
                    // Si la plataforma no tiene simbolo, se finaliza.
                    if (plataform.symbolPost == null)
                    {
                        Debug.Log("Falta simbolo en " + plataform.transform.parent.name);
                        return;
                    }
                }

                // Si todas las plataformas tienen un simbolo.
                // Se les activa el recorrido por los esatdos.
                foreach (PlatformPutObject plataform in plataforms)
                {                    
                    plataform.transform.parent.
                        GetComponentInChildren<WaypointManager>().enabled = true;
                }
            }
        }
    }
}
