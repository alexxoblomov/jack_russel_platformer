using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public Transform groundCheck; // Позиция для проверки земли
    public float groundCheckRadius = 0.2f; // Радиус проверки
    public LayerMask groundLayer; // Слой для земли
    private bool isGrounded;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        CheckGround();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");

        // Установка параметров анимации
        animator.SetBool("isRunning", Mathf.Abs(moveInput) > 0.1f);
        animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);

        // Движение игрока
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void OnDrawGizmos()
    {
        // Визуализация области проверки земли в редакторе
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}