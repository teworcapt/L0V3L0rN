using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNextScene : MonoBehaviour
{
    [Header("Components")]
    public Animator transitionAnim;
    public float Cutscenetime;

    public GameObject transition;


    // Start is called before the first frame update
    private void Awake()
    {
        transition.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(NextScene());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(Cutscenetime);
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1f);
        transition.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
}
