using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingsScript : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] trees;// tree2, tree3, tree4, tree5, tree6, tree7, tree8, tree9;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        int random1;
        random1 = Random.Range(0,9);

        rend.sprite = trees[random1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
