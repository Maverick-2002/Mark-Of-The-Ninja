using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    private float direction;
    private bool DoubleJump;
    [SerializeField] private float Movespeed = 8f;
    [SerializeField] private float JumpForce = 7f;
    [SerializeField] private LayerMask JumpGround;
    private enum AnimationStates { idle, running, falling, jumping }

    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource PowerupSound;
    [SerializeField] private AudioSource PowerResetSound;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(direction * Movespeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                JumpSound.Play();
                DoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }

            else if (DoubleJump)
            {
                JumpSound.Play();
                DoubleJump = false;
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }



        UpdateAnimation();
    }
   
    private void UpdateAnimation()
    {
        AnimationStates state;

        //Running Animation
        if (direction > 0f)
        {
            state = AnimationStates.running;
            sprite.flipX = false;
        }
        else if (direction < 0f)
        {
            state = AnimationStates.running;
            sprite.flipX = true;
        }
        else
        {
            state = AnimationStates.idle;
        }

        //Jumping Animation
        if (rb.velocity.y > 0.1f)
        {
            state = AnimationStates.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = AnimationStates.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpGround);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectables(PowerUp=Chilli)"))
        {
            Destroy(collision.gameObject);
            PowerupSound.Play();
            Debug.Log("PowerUp Speed");
            Movespeed = 11f;
            sprite.color = Color.red;
            StartCoroutine(ResetPower());
        }
        if (collision.gameObject.CompareTag("Collectables(PowerUp=GreenChilli)"))
        {
            Destroy(collision.gameObject);
            PowerupSound.Play();
            Debug.Log("PowerUp Jump");
            JumpForce = 7f;
            sprite.color = Color.cyan;
            StartCoroutine(ResetPower());
        }

    }
    private IEnumerator ResetPower()
    {
        
        yield return new WaitForSeconds(6);
        PowerResetSound.Play();
        Movespeed = 8f;
        JumpForce = 5.5f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}

