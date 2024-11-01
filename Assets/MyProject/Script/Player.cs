using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    private CharacterController controller;

    [SerializeField] public float walkSpeed = 5.0f;       // Velocidade no solo
    [SerializeField] public float flightSpeed = 8.0f;     // Velocidade no ar
    [SerializeField] public float gravity = -9.81f;       // For�a da gravidade
    [SerializeField] public float jumpHeight = 2.0f;      // Altura do pulo
    [SerializeField] public float flightHeightSpeed = 3.0f;  // Velocidade de subir/descer no voo

    [SerializeField] public bool playerAnimalArara;

    private Vector3 velocity;
    private bool isGrounded;
    private bool canWalk = true;
    [SerializeField] private bool isFlying = false;
    [SerializeField] int seeds;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verificar se est� no ch�o
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Resetar a velocidade ao tocar o ch�o
        }

        if (isGrounded && isFlying)
        {
            isFlying = false;
        }

        // Alternar entre andar e voar ao pressionar "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Se o jogador n�o estiver jogando como arara, n�o conseguira voar
            if (!playerAnimalArara) return;

            // Se o jogador estiver no ch�o, n�o ativa o modo voo (precisa estar no ar para voar)
            if (isGrounded) return;

            isFlying = !isFlying;
            if (isFlying)
            {
                velocity.y = 0;  // Resetar a velocidade vertical ao come�ar a voar
            }
        }

        // Movimenta��o e inputs
        if (!isFlying)
        {
            // Movimenta��o no ch�o
            MoveOnGround();
        }
        else
        {
            // Movimenta��o no voo
            Fly();
        }

        // Aplicar a movimenta��o no Character Controller
        controller.Move(velocity * Time.deltaTime);
    }

    void MoveOnGround()
    {
        if (canWalk)
        {
            // Entrada de movimenta��o no solo
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            controller.Move(move * walkSpeed * Time.deltaTime);

            // Pular
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Aplicar gravidade no ch�o
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void Fly()
    {
        // Entrada de movimenta��o no voo
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * flightSpeed * Time.deltaTime);

        // Controle da altura no voo
        if (Input.GetKey(KeyCode.Space)) // Subir
        {
            velocity.y = flightHeightSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl)) // Descer
        {
            velocity.y = -flightHeightSpeed;
        }
        else
        {
            if (seeds >= 1)
            {
                velocity.y += gravity * (seeds / 4 ) * Time.deltaTime;
            }

            velocity.y += gravity * Time.deltaTime;  // Aplicar gravidade no voo
        }
    }

}
