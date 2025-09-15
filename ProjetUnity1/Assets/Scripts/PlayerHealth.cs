using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void Die()
    {
        // Joue l'animation de mort
        animator.SetTrigger("Die");
        spriteRenderer.enabled = false;

        Invoke(nameof(Respawn), 1f);
    }


    public void Respawn()
    {
        transform.position = respawnPoint.position;
        spriteRenderer.enabled = true;
    }
}
