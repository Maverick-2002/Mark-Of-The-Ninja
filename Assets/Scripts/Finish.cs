using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private AudioSource FinishSound;
    private bool LevelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ninja" && !LevelComplete)
        {
            FinishSound.Play();
            LevelComplete = true;
            Invoke("CompleteLevel", 0.5f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
