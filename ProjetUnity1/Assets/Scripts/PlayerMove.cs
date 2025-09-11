using System;
using UnityEngine;
 
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private AudioClip sfxJump;
 
    private AudioSource audioSource;
    private float x;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool jump = false;
 
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(x));
        transform.Translate(Vector2.right * 7f * Time.deltaTime * x);

        if (x > 0f) spriteRenderer.flipX = false;
        if (x < 0f) spriteRenderer.flipX = true;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = true;
            audioSource.PlayOneShot(sfxJump);
        }

        // Faut maintenir
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     animator.SetBool("IsAttacking", true);
        // }
        // else
        // {
        //     animator.SetBool("IsAttacking", false);
        // }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Il frappe");
            animator.SetTrigger("Attack");  
        }
    }
 
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * 7f * Time.deltaTime * x);
 
        if (jump)
        {
            jump = false;
            rb.AddForce(Vector2.up * 900f);
        }
 
    
    }
}