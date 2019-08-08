using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private Camera cam;
    void Awake()
    {
        cam = Camera.main;
        cam.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (cam)
        {
            //This enables the orthographic mode
            cam.orthographic = true;
            //Set the size of the viewing volume you'd like the orthographic Camera to pick up (5)
            cam.orthographicSize = 50.0f;
            Debug.Log(cam.orthographicSize);

        }
        // Debug.Log(cam.ortographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
