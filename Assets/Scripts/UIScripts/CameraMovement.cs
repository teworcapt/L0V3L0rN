using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
    public static bool cameraExists;

    // Start is called before the first frame update
    void Start()
    {
        if(!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
