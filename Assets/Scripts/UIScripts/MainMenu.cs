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
        Application.OpenURL("https://docs.google.com/document/d/1A0SxpLEWufr9vfMzz5u5j4Mj8p4i0yEP8AKZIZew18o/edit?usp=sharing");
    }

}
