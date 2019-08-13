using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public static string name;
        public static Vector3 startingPos;                // which position we entered the actual level, to create a brick road on few bricks on enter
        public static Vector3 endingPos;                   // position where we go to next level
        public static int tilesAmount;                    // how much times we create
        public static int length = 2;                         // what is actual widht/height of our level ( we make a square)

    }
    //public Sprite[] tiles;                   // from which tiles we create our level
    // public GameObject[] tiles2;                 // different type of tiles ( snow, forest)
    public List<Vector3> createdTiles;
    public bool timeToCreateLevel = false;
    public Vector3 abc = new Vector3(0f, 0f, 0f);
    public Vector3 abc1 = new Vector3(3f, 3f, 0f);
    public GameObject[] centerMapSprites;
    public int licznik;
    public float timer = 0f;
    public float time = 2f;
    public string MapType;                
        
        
        /// </summary>
    // void Awake() {
    //  spritesObject = new GameObject[Level.length];
    //}
    // Start is called before the first frame update
    void Start()
    {
        timeToCreateLevel = true;
        //spritesObject = new GameObject[Level.length];
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timeToCreateLevel == true)
        {
            Vector3 poczatek = new Vector3(0f, 0f, 0f);
            Vector3 koniec = new Vector3(5f, 5f, 0f);
            timeToCreateLevel = false;
            setLevel("abc555", poczatek, koniec, 6);
            drawLevel(centerMapSprites);
            

        }
    }

    public static void setLevel(string name1, Vector3 startingPos1, Vector3 endingPos1, int length1)
    {

        Level.name = name1;
        Level.startingPos = startingPos1;
        Level.endingPos = endingPos1;
        Level.tilesAmount = length1 * 2;
        Level.length = length1;

    }
    public void drawLevel(GameObject[] spritesObj1)
    {

            int LenghtHelpX1 = Level.length;
            int LenghtHelpY = Level.length;
            int licznik = -Level.length;

        if (MapType == "desert")                            // type of map 
        {
            Debug.Log(MapType);
            /////////////////////////////////////////////////////////////////////////////// acquiring objects from main tab
            spritesObj1 = new GameObject[centerMapSprites.Length];
            spritesObj1[0] = centerMapSprites[0];
            spritesObj1[1] = centerMapSprites[1];
            spritesObj1[2] = centerMapSprites[2];
            spritesObj1[3] = centerMapSprites[3];
            spritesObj1[4] = centerMapSprites[4];
            spritesObj1[5] = centerMapSprites[5];
            spritesObj1[6] = centerMapSprites[6];
            spritesObj1[7] = centerMapSprites[7];
            spritesObj1[8] = centerMapSprites[8];
            spritesObj1[9] = centerMapSprites[9];
        }
            Vector3 pos = new Vector3();


        for (int LenghtX = -Level.length; LenghtX <= Level.length; LenghtX++)
        {
            for (int LenghtY = -Level.length; LenghtY <= Level.length; LenghtY++)
            {
                pos.Set(LenghtX, LenghtY, 0);
                /////////////////////////////////////////////////////////////////////////////// surroundings
                  if (pos.x == -Level.length || pos.x == Level.length || pos.y == -Level.length || pos.y == Level.length)
                 {
                     
                    Instantiate(spritesObj1[1], pos, Quaternion.identity);
                 }
                /////////////////////////////////////////////////////////////////////////////// corners
                else if (pos.x == -Level.length + 1 && pos.y == -Level.length + 1) {
                    Instantiate(spritesObj1[6], pos, Quaternion.identity);
                }
                else if (pos.x == -Level.length + 1 && pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj1[7], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1 && pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj1[8], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1 && pos.y == -Level.length + 1)
                {
                    Instantiate(spritesObj1[9], pos, Quaternion.identity);
                }
                /////////////////////////////////////////////////////////////////////////////// sides
                else if (pos.x == -Level.length + 1)
                {
                    Instantiate(spritesObj1[4], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1)
                {
                    Instantiate(spritesObj1[2], pos, Quaternion.identity);
                }
                else if (pos.y == -Level.length + 1)
                {
                    Instantiate(spritesObj1[3], pos, Quaternion.identity);
                }
                else if (pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj1[5], pos, Quaternion.identity);
                }
                /////////////////////////////////////////////////////////////////////////////// center
                else
                    Instantiate(spritesObj1[0], pos, Quaternion.identity);
            }
        
        }
    }
}
