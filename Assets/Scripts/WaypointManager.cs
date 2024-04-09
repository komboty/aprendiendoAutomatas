using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla todos los puntos de ruta.
/// </summary>
public class WaypointManager : MonoBehaviour
{
    // Constantes del juego.
    public Constants constants;
    // Objeto a mover al punto de ruta.
    public GameObject moveObject;
    // Velocidad para llegar a los puntos de ruta.
    public float speed;
    // Punto a llegar.
    public Transform target;
        
    void Start()
    {
        speed = constants.speedWaypoints;
        LookAtTarget();
    }
        
    void Update()
    {
        // Se avanza de frente.
        moveObject.transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerStay(Collider other)
    {
        // Si se llego al punto de ruta.
        if (other.CompareTag(constants.tagWaypoint))
        {
            // Se asigna el nuevo punto de ruta.
            target = other.GetComponent<Waypoint>().nextPoint;
            //Debug.Log("Siguinete " + target.name);
            LookAtTarget();
        }
    }

    private void LookAtTarget()
    {
        //moveObject.transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        moveObject.transform.LookAt(target.position);
    }
}
