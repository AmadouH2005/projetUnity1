using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerObject : MonoBehaviour
{
    private void OnTriggerEnter2D(BoxCollider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("touché");
            collision.GetComponent<PlayerHealth>().Die();
        }
    }
}
