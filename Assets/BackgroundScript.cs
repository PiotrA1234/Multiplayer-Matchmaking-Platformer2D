using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
   float BgLength = 0f;
    private LevelGenScript levelGeneratorObj;
    // Start is called before the first frame update
    void Start()
    {
        levelGeneratorObj = GameObject.FindObjectOfType<LevelGenScript>();
        BgLength = (float)levelGeneratorObj.levelLength;
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.localScale = new Vector3(BgLength * 3.5f, BgLength * 3.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
