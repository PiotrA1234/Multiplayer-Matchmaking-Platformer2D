using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object
    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    private float offset1=5f;
    public LevelGenScript levelGeneratorObj;
    private Camera cam;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Awake() {
        cam = Camera.main;
    }
    // Use this for initialization
    void Start()
    {
        
        levelGeneratorObj = GameObject.FindObjectOfType<LevelGenScript>();
        float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;
        float halfHeight = cam.orthographicSize;
        float halfWidth = cam.aspect * halfHeight;

        maxPosition = new Vector2(levelGeneratorObj.levelLength - offset1, levelGeneratorObj.levelLength - offset1);
        minPosition = new Vector2(-levelGeneratorObj.levelLength + offset1, -levelGeneratorObj.levelLength + offset1);

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
            Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, -35f);
            target.x = Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x);
            target.y = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Vector3.Lerp(transform.position, target, 0.6f);
        Debug.Log(transform.position);
          
    }
}