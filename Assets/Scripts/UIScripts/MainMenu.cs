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
        Application.OpenURL("https://docs.google.com/document/d/1Uk7dQAKjfAfilV2lYIu6tAdr3mL5g0esUT4fSKbsdMo/edit?usp=sharing");
    }

}
