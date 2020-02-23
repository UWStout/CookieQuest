using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if(!paused)
            {
                pauseGame();

            } else
            {
                resumeGame();
            }
 
        }
    }

    public void pauseGame()
    {
        paused = true;
        Debug.Log("Paused");
        Time.timeScale = 0.0f;
        pauseUI.SetActive(paused);

    }

    public void resumeGame()
    {
        paused = false;
        Debug.Log("Unpaused");
        Time.timeScale = 1.0f;
        pauseUI.SetActive(paused);
    }

    public void quitGame()
    {
        //For use in editor.
        UnityEditor.EditorApplication.isPlaying = false;

        //Uncomment if building for final build
        //Application.Quit();
    }

}
