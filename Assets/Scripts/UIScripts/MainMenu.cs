using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //loads scene based on index number
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Credits()
    {
        Application.OpenURL("https://itch.io/c/3725824/l0v3l0rn-used-assets");
    }

}
