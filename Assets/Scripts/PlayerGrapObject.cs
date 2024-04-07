using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Script que implementa el agarre de objeto.
/// </summary>
public class PlayerGrapObject : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Punto de agarre.
    public GameObject gripPoint;
    // Objeto agarrado.
    public GameObject grabbedObject = null;
    
    void Update()
    {
        // Soltar un objeto.
        // Si se tiene un objeto agarrado.
        if (grabbedObject != null)
        {
            // Si se oprimio el Boton 2.
            if (Input.GetButton(constants.nameInputBtn2))
            {
                Debug.LogWarning("Soltar Objeto");

                // Se ponen las fisicas del objeto a agarrado.
                Rigidbody rigidbodyOther = grabbedObject.GetComponent<Rigidbody>();
                rigidbodyOther.useGravity = true;
                rigidbodyOther.isKinematic = false;

                // El objeto agarrado se suelta.
                grabbedObject.gameObject.transform.SetParent(null);

                // Se quita el objeto agarrado del Script.
                grabbedObject = null;
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {        
        // Si se tiene al alcanze un objeto agarrable.
        if (other.gameObject.CompareTag(constants.tagGraspable))
        {
            // Si se oprimio el Boton 1 y no se tiene agarrado un objeto.
            if (Input.GetButton(constants.nameInputBtn1) && grabbedObject == null)
            {
                Debug.LogWarning("Agarrar Objeto");

                // Se quita las fisicas del objeto a agarrar.
                Rigidbody rigidbodyOther = other.GetComponent<Rigidbody>();
                rigidbodyOther.useGravity = false;
                rigidbodyOther.isKinematic = true;

                // El objeto agarrado se posiciona en el punto de agarre.
                other.transform.position = gripPoint.transform.position;
                other.gameObject.transform.SetParent(gripPoint.transform);

                // Se asigna el objeto agarrado al Script.
                grabbedObject = other.gameObject;
            }
        }
    }
}
