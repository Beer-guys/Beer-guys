using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f; // Rychlost pohybu hráèe
    public float jumpForce = 10f; // Síla skoku
    public float groundCheckRadius = 0.2f; // Polomìr kontrolního kruhu pro ground check
    public LayerMask groundLayer; // Vrstva pro ground check

    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        bool isGrounded = IsGrounded(); // Zjistíme, zda hráè stojí na zemi
        MovePlayer();
        if (isGrounded && Input.GetButtonDown("Jump")) // Skok pouze pokud stojíme na zemi
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        // Použijeme OverlapCircle pro ground check na základì vrstvy "Ground"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, groundCheckRadius, groundLayer);

        // Vrátíme true, pokud je alespoò jeden collider v kolekci colliders
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject) // Ignorujeme kolizi s vlastním hráèem
            {
                return true;
            }
        }

        return false;
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Získáme hodnotu osy X (A a D nebo šipky vlevo/vpravo)

        Vector2 targetVelocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Plynulý pøechod mezi aktuální rychlostí a cílovou rychlostí
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.deltaTime * 10f);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Pøidáme vertikální rychlost pro provedení skoku
    }


}
