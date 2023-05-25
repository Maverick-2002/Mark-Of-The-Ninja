using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public Animator Animator;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource EnemyDieSound;
    [SerializeField] private AudioSource EnemyHurtSound;
    //public GameObject deathEffect;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        EnemyHurtSound.Play();
        health -= damage;
        

        if (health <= 0)
        {
            Die();
            EnemyDieSound.Play();
        }
    }

    void Die()
    {
        if (GetComponentInParent<EnemyPatrol>() != null)
        {
            GetComponentInParent<EnemyPatrol>().enabled = false;
        }
        if (GetComponent<Enemy>() != null)
        {
            GetComponentInParent<Enemy>().enabled = false;
        }
        GetComponent<BoxCollider2D>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        Animator.SetTrigger("Die");
       
    }

}