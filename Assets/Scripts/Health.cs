using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }
    private Animator Animator;
    private bool death = false;
    private TriggerDeath Dead;
    [SerializeField] private AudioSource HealthSound;

    private void Awake()
    {
        currenthealth = startingHealth;
        Animator = GetComponent<Animator>();
        Dead = GetComponent<TriggerDeath>();
    }
    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, startingHealth) ;
        HealthSound.Play();
        
        if (currenthealth > 0 )
        {
            Debug.Log("Care Full");
        }
        else
        {
            if (!death)
            {
                Dead.Die();
                death = true;
            }
            
        }   
    }
    public void AddHealth(float health)
    {
        currenthealth = Mathf.Clamp(currenthealth + health, 0, startingHealth);
    }
}
