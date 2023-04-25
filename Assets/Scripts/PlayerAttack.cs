using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] private AudioSource AttackSound;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }
    void Attack()
    {
        AttackSound.Play();
        Animator.SetTrigger("Attack");

    }
}
