using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Modelo 3D del estado.
    public GameObject modelState;
    // Nombre del simbolo a verificar.
    public string nameSymbol;

    private void OnTriggerStay(Collider other)
    {
        // Si pasa una plataforma.
        if (other.gameObject.CompareTag(constants.tagPlatform))
        {
            //Debug.LogWarning("Paso " + other.transform.parent.name);

            // Se obtiene el simbolo puesto en la plataforma
            GameObject symbol = other.GetComponent<PlatformPutObject>().putSymbol;

            /* Si la plataforma no tiene simbolo.
            if (symbol == null)
            {
                Debug.LogWarning("Plataforma sin simbolo");
                return;
            }*/

            // Si el nombre del simbolo es igual al del estado.
            if (symbol.name.Equals(nameSymbol))
            {
                // Se destruye la plataforma.
                Destroy(other.transform.parent.gameObject);
                // Se pone el material que tiene la plataforma.
                modelState.GetComponent<MeshRenderer>().material = symbol.gameObject
                    .GetComponent<MeshRenderer>().material;
                Destroy(this.gameObject);
            }
            // Si el nombre del simbolo NO es igual al del estado.
            else
            {
                Debug.LogWarning("Cadena no valida");
            }
        }
    }
}
