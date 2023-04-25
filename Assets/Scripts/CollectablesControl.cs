using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesControl : MonoBehaviour
{
    
    private int ninjastar = 0;
    private int coins = 0;
    [SerializeField] private Text ninjastarText;
    [SerializeField] private Text coinsText;
    private Health PlayerHealth;
    public Animator Animator;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource NinjaStarSound;
    [SerializeField] private AudioSource HealingSound;
    public void Start()
    {
        PlayerHealth = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Destroy(collision.gameObject);
            HealingSound.Play();
            PlayerHealth.AddHealth(1);

        }
        if (collision.gameObject.CompareTag("Collectables(NinjaStar)"))
        { 
            Destroy(collision.gameObject);
            NinjaStarSound.Play();
            ninjastar++;
            Debug.Log("NinjaStar:" +  ninjastar);
            ninjastarText.text = "Ninjastar:" + ninjastar;
        }
        if (collision.gameObject.CompareTag("Collectables(Coins)"))
        {
            Destroy(collision.gameObject);
            CoinSound.Play();
            coins++;
            Debug.Log("Coins:" + coins);
            coinsText.text = "Coins:" + coins;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (ninjastar > 0)
            {
                Animator.SetTrigger("NinjaStar");
                ninjastar--;
            }
        }
        
    }
}
