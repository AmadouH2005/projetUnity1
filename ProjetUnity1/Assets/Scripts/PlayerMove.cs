using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private AudioSource audioSource;
    private float x;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Déplacement horizontal
        x = Input.GetAxisRaw("Horizontal"); 
        animator.SetFloat("Speed", Mathf.Abs(x));

        // Flip du sprite
        if (x > 0f) spriteRenderer.flipX = false;
        if (x < 0f) spriteRenderer.flipX = true;

        // Vérifier si on touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.PlayOneShot(sfxJump);
            Debug.Log("Il saute");
        }

        // Attaques
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Il frappe");
            animator.SetTrigger("Kick");
        }

        if (Input.GetKeyDown(KeyCode.K)){
            animator.SetTrigger("leftPunch");
        }
        if (Input.GetKeyDown(KeyCode.L)){
            animator.SetTrigger("uppercut");
        }
        // if (Input.GetKeyDown(KeyCode.L)){
        //     animator.SetTrigger("rightPunch");
        // }

        // Combo
        // if (Input.GetKeyDown(KeyCode.O)){
        //     animator.SetTrigger("uppercut") & animator.SetTrigger("uppercut");
        // }
    }

    private void FixedUpdate()
    {
        // Déplacement physique
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }

}