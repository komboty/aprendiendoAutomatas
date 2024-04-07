using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que controla el comportamiento del Jugador.
/// </summary>
public class Player : MonoBehaviour
{
    // Variable con constantes de todo el juego.
    public Constants constants;
    // Velocidad del jugador.
    public float speed;
    // Fisicas del jugador;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        speed = constants.speedPlayer;
    }

    void Update()
    {
        float moveX = Input.GetAxis(constants.nameGetAxisX);
        float moveZ = Input.GetAxis(constants.nameGetAxisZ);

        rigidbody.velocity = new Vector3(
            moveX * speed, rigidbody.velocity.y, moveZ * speed);

    }
}
