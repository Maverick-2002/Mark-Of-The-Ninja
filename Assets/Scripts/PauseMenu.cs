using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PMenu;
    public static bool GamePaused = false;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Pause()
    {
        PMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
    public void Resume()    
    {
        PMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void Home (int sceneId) 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneId);

    }
}
