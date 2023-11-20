using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScene : MonoBehaviour
{
    [Header("Components")]
    private PlayerManager player;
    public Animator transitionAnim;
    public int sceneBuildIndex;
    public string exitPoint;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(LoadLevel());
            player.startPoint = exitPoint;
        }
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        transitionAnim.SetTrigger("Start");
    }

}
