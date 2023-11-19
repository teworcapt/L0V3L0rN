using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScene : MonoBehaviour
{
    public int sceneBuildIndex;
    public string exitPoint;
    private PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            player.startPoint = exitPoint;
        }
    }
}
