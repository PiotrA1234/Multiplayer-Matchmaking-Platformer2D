using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour

{
    [System.Serializable]
    public class Player {
        public Vector3 playerPosition;
        public Transform transform;
        public int characterFacingSide; // after we know the position of our enter to level, we use characterFacingSide to rotate him in proper way and create bricks in proper way(we enter top and we want bricks to create down of this pos)
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
