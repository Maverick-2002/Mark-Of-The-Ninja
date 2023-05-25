using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animator;
    [SerializeField] private AudioSource AttackSound;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayers;
    public int damage = 40;


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
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackpoint.position,attackrange, enemylayers);
        foreach(Collider2D enemy in hitenemy)
        {
            enemy.GetComponent<Enemy>().TakeDamage(40);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }

}
