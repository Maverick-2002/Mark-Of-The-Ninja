using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesControl : MonoBehaviour
{
    
    public int ninjastar;
    private int coins;
    [SerializeField] private Text ninjastarText;
    [SerializeField] private Text coinsText;
    private Health PlayerHealth;
    public Animator Animator;
    [SerializeField] private AudioSource CoinSound;
    [SerializeField] private AudioSource NinjaStarSound;
    [SerializeField] private AudioSource HealingSound;
    public Transform Throwpoint;
    public GameObject ThrowpointPrefab;
    [SerializeField] private AudioSource StarSound;
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
        
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && ninjastar > 0)
        {

            Animator.SetTrigger("NinjaStar");
            StarSound.Play();
            Shoot();
            ninjastar--;
            ninjastarText.text = "Ninjastar:" + ninjastar;

        }
    }
    void Shoot()
    {
        Instantiate(ThrowpointPrefab, Throwpoint.position, Throwpoint.rotation);
    }

}
