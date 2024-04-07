using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que controla el movimiento del Jugador.
/// </summary>
public class PlayerMove : MonoBehaviour
{
    // Variable con constantes de todo el juego.
    public Constants constants;
    // Controlador del jugador.
    public CharacterController characterController;
    // Velocidad del jugador.
    public float speed;
    // Giro del jugador.
    public float turnSmoothTimePlayer;
    private float turnSmoothVelocityPlayer;
    // Camara del jugador.
    public Transform cameraTransform;
    // Fisicas del jugador;
    // private Rigidbody rigidbody;

    private void Awake()
    {
        //rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        speed = constants.speedPlayer;
        turnSmoothTimePlayer = constants.turnSmoothTimePlayer;
        //turnSmoothVelocityPlayer = constants.turnSmoothVelocityPlayer;
}

    void Update()
    {
        // Se obtiene el evento de cuando se oprime algun boton.
        float moveHorizontal = Input.GetAxis(constants.nameGetAxisX);
        float moveVertical = Input.GetAxis(constants.nameGetAxisZ);
        // Vector con la direccion a mover el personaje.
        Vector3 direction = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Si se quiere mover el jugador, se mueve el personaje.
        if (direction.magnitude >= constants.limitDirectionMovePlayer)
        {
            // Angulo de la direccion a mover.
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + 
                cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, 
                ref turnSmoothVelocityPlayer, turnSmoothTimePlayer);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Se rota y mueve el personaje a la direccion indicada.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
