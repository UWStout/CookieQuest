using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScreenScript : MonoBehaviour
{
    public void Retry(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        //For use in editor.
        //UnityEditor.EditorApplication.isPlaying = false;

        //Uncomment if building for final build
        Application.Quit();

    }
}
