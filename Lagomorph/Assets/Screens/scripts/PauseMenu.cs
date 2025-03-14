using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        PauseMenuCanvas.SetActive(false); // Ensure the pause menu is hidden initially
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            if (Paused) // Fixed the check from "Pause" to "Paused"
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {
        // Ensure that you are calling LoadScene correctly
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

} 
