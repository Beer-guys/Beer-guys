using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Rychlost pohybu hr��e
    public float jumpForce = 10f; // S�la skoku
    public float groundCheckRadius = 0.2f; // Polom�r kontroln�ho kruhu pro ground check
    public LayerMask groundLayer; // Vrstva pro ground check
    public Animator animator; //Animace

    private Rigidbody2D rb;
    private Collider2D playerCollider;

    bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        rb.freezeRotation = true; // Nastav�me fixedRotation na true
    }

    private void Update()
    {
        bool isGrounded = IsGrounded(); // Zjist�me, zda hr�� stoj� na zemi
        MovePlayer();
        if (isGrounded && Input.GetButtonDown("Jump")) // Skok pouze pokud stoj�me na zemi
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
    }

    private bool IsGrounded()
    {
        // Pou�ijeme OverlapCircle pro ground check na z�klad� vrstvy "Ground"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius, groundLayer);

        // Vr�t�me true, pokud je alespo� jeden collider v kolekci colliders
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) // Ignorujeme kolizi s vlastn�m hr��em
            {
                return true;
            }
        }

        return false;
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Z�sk�me hodnotu osy X (A a D nebo �ipky vlevo/vpravo)

        Vector2 targetVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (horizontalInput > 0 && !facingRight) flip();
        else if (horizontalInput < 0 && facingRight) flip();





        animator.SetFloat("speed", Mathf.Abs(horizontalInput)); // Animace pohybu

        // Plynul� p�echod mezi aktu�ln� rychlost� a c�lovou rychlost�
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * 10f);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // P�id�me vertik�ln� rychlost pro proveden� skoku
    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
}