using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Referências")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cameraTransform; // Referência da Câmera

    private CharacterController controller;
    private Vector2 inputVector;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }

        // Se a câmera não for atribuída no Inspector, busca a MainCamera da cena automaticamente
        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // 1. Obter as direções da câmera no espaço do mundo
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // 2. Zerar a componente Y para o movimento ser puramente no plano horizontal (X/Z)
        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        // 3. Calcular a direção de movimento combinando as entradas com a orientação da câmera
        Vector3 moveDirection = (camForward * inputVector.y + camRight * inputVector.x).normalized;

        // 4. Movimentação e Rotação do Personagem
        if (moveDirection.magnitude >= 0.1f)
        {
            // Rotacionar o personagem na direção do movimento calculado
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Mover o personagem
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        // 5. Atualização do parâmetro do Animator
        if (animator != null)
        {
            animator.SetFloat("Speed", moveDirection.magnitude, 0.1f, Time.deltaTime);
        }

        // 6. Aplicação de gravidade simples
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}