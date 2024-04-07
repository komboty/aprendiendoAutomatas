using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla el movimiento del Jugador.
/// </summary>
public class PlayerMove : MonoBehaviour
{
    // Constantes del juego.
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

    void Start()
    {
        // Se asignan los valores por default.
        speed = constants.speedPlayer;
        turnSmoothTimePlayer = constants.turnSmoothTimePlayer;
    }

    void Update()
    {
        // Se obtiene el evento de cuando se oprime algun boton.
        float moveHorizontal = Input.GetAxis(constants.nameInputX);
        float moveVertical = Input.GetAxis(constants.nameInputZ);
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
