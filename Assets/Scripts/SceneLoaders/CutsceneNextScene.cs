using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneNextScene : MonoBehaviour
{
    public float Cutscenetime;
    public Animator transitionAnim;
    public PlayerManager player;
    public AudioClip CutsceneAudio;
    public AudioSource Cam;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        Destroy(player);
        StartCoroutine(NextScene());
        Cam = GetComponent<AudioSource>();

        Cam.clip = CutsceneAudio;
        Cam.Play();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
}
