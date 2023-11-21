using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNextSceneBathroom : MonoBehaviour
{

    // tewo's note: yes I duplicated it because I don't know atm how to optimize the syntax into one and I'm running out of time.
    [Header("Components")]
    public Animator transitionAnim;
    public float Cutscenetime;

    public GameObject player;
    public GameObject transition;

    public AudioSource source;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        player.SetActive(false);
        transition.SetActive(false);
        if (GameObject.FindWithTag("MainCamera"))
        {
            source = FindFirstObjectByType<AudioSource>();
            source.volume = 0;
        }
    }

    void Start()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(Cutscenetime);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        transition.SetActive(true);
        source.volume = 0.5f;
        player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
}
