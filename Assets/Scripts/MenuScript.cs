using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        //For use in editor.
        //UnityEditor.EditorApplication.isPlaying = false;

        //Uncomment if building for final build
        Application.Quit();

    }

}
