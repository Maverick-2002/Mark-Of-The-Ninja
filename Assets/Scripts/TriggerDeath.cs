using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TriggerDeath : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Health PlayerHealth;
    private int LifeCount = 3;
    [SerializeField] private AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerHealth = GetComponent<Health>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {

           PlayerHealth.TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("DeathTraps"))
        {

            Die();
        }
       
    }

    public void Die()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        anim.SetTrigger("Death");
        DeathSound.Play();
        Debug.Log("Die Die Die");
        rb.bodyType = RigidbodyType2D.Static;
    }

   private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

}
