using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public Transform player;
    private float zero;
    // Start is called before the first frame update
    void Start()
    {
        LevelGenerator.Level.name = "abc";
        string name1 = LevelGenerator.Level.name;
        //Debug.Log(name1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
