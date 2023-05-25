using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public Transform Throwpoint;
    public GameObject ThrowpointPrefab;
    public Animator Animator;
    [SerializeField] private AudioSource StarSound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Animator.SetTrigger("NinjaStar");
            StarSound.Play();
            Shoot();
        }
    }

    void Shoot ()
    {
        Instantiate(ThrowpointPrefab, Throwpoint.position, Throwpoint.rotation);
    }
}
