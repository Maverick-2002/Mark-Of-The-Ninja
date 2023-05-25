using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    private Animator Animator;
    private Rigidbody2D rb;
    BoxCollider2D bc;

   

    private void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       /* if (GetComponentInParent<EnemyPatrol>() != null)
        {
            GetComponentInParent<EnemyPatrol>().enabled = false;
        }
        if (GetComponent<Enemy>() != null)
        {
            GetComponentInParent<Enemy>().enabled = false;
        } */
        rb.bodyType = RigidbodyType2D.Static;
        bc.enabled = false;
        Animator.SetTrigger("Die");
       
    }

}