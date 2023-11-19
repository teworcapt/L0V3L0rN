using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScene : MonoBehaviour
{
    private PlayerManager player;
    private CameraMovement cameraMovement;

    public string spawnpointName;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManager>();

        if (player.startPoint == spawnpointName)
        {
            cameraMovement = FindObjectOfType<CameraMovement>();
            player.transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);
            cameraMovement.transform.position = new Vector3(transform.position.x, transform.position.y, cameraMovement.transform.position.z);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
