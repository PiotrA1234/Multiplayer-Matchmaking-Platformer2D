using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenScript : MonoBehaviour
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

    public bool timeToCreateLevel = false;
    public GameObject[] centerMapSprites;
    public GameObject[] neutralSprites;
    public GameObject[] enviromentSprites;
    public int licznik = 5;
    public float timer = 0f;
    public float time = 2f;
    public string MapType;                  /// tutaj ustalam map type i w linijkach 80 wtedy dla danego typu mapy np desert, grass, winter ustawiam level
    public int levelLength = 30;
    private float oasisSpawnMultiplierLower = 0.75f;
    private float oasisSpawnMultiplierHigher = 0.85f;
    public float chanceForNeutralEnviroment=0.1f;
   
    void Awake()
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
            setLevel("abc555", poczatek, koniec, levelLength);
            drawLevel(centerMapSprites);
            drawNeutralSurroundings(2.5f);
            createEnviroment(enviromentSprites);

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
    public void drawNeutralSurroundings(float neutralObjectChance)
    {
        GameObject[] neutralObj;
        neutralObj = new GameObject[neutralSprites.Length];

        float randomCampX = 0f, randomCampY = 0f;
        float oasisX = -Level.length * oasisSpawnMultiplierLower;
        float oasisY = Level.length * oasisSpawnMultiplierLower;

        float LevelLength1;
        bool chooseCornerForOasis = (Random.value > 0.5f);
        Debug.Log(chooseCornerForOasis);
        if (chooseCornerForOasis == true)
        {
            LevelLength1 = -Level.length * oasisSpawnMultiplierHigher;
        }
        else
        {
            LevelLength1 = Level.length * oasisSpawnMultiplierHigher;
            oasisX = -oasisX;
        }
        float LevelLength2 = Level.length * oasisSpawnMultiplierHigher;
        Vector3 position = new Vector3(randomCampX, randomCampY, 0);                //acting as a corner for our local x and y coordinates oasis camp


        for (int i = 0; i < neutralSprites.Length; i++)             //get objects to make 1 oasis on the neutralObj table
        {
            neutralObj[i] = neutralSprites[i];
        }

        for (int j = 0; j < 2; j++)                           // create 2 oasis in opposite corners of map
        {

            randomCampX = Random.Range(LevelLength1, oasisX);                   //min and max position values for random oasis respawn
            Debug.Log(randomCampX);
            randomCampY = Random.Range(LevelLength2, oasisY);
            Debug.Log(randomCampY);
            // if (randomCampY > 0 && position1X > 0) {                        /// dokonczyc respienie oaz jesli odlegloscjest mniejsza niz np 30 to nie respic ... 
            //if(randomCampY-)
            // }

            float position1X = randomCampX + 2f;
            float position1Y = randomCampY;

            float position2X = randomCampX + 1.8f;
            float position2Y = randomCampY - 1.3f;

            float position3X = randomCampX + 1f;
            float position3Y = randomCampY - 2.7f;

            float position4X = randomCampX + 3.1f;
            float position4Y = randomCampY - 2.7f;

            position.Set(randomCampX, randomCampY, 0f);
            Instantiate(neutralObj[0], position, Quaternion.identity);
            position.Set(position1X, position1Y, 0f);
            Instantiate(neutralObj[1], position, Quaternion.identity);
            position.Set(position2X, position2Y, 0f);
            Instantiate(neutralObj[2], position, Quaternion.identity);
            position.Set(position3X, position3Y, 0f);
            Instantiate(neutralObj[3], position, Quaternion.identity);
            position.Set(position4X, position4Y, 0f);
            Instantiate(neutralObj[4], position, Quaternion.identity);
            position.Set(randomCampX, randomCampY, 0);

            oasisX = -oasisX;
            oasisY = -oasisY;
            LevelLength1 = -LevelLength1;
            LevelLength2 = -LevelLength2;

        }

    }
    public void createEnviroment(GameObject[] enviromentSpritesObj)
    {
        bool respawnChance=true;
        float leftToRightNumerator = Level.length * -oasisSpawnMultiplierHigher;
        int numberOfSprite = Random.Range(0, enviromentSprites.Length);
        enviromentSpritesObj = new GameObject[enviromentSprites.Length];
        Vector3 position = new Vector3(0f, 0f, 0f);
        for (int i = 0; i < enviromentSprites.Length; i++)
        {
            enviromentSpritesObj[i] = enviromentSprites[i];
        }

        for (float j = -Level.length * oasisSpawnMultiplierLower; j < Level.length * oasisSpawnMultiplierLower; j++) {              // poprawic to kurwa jak wroce w poneidzialek rano znaczyok
            for (float k = leftToRightNumerator; k < -leftToRightNumerator; k++) {
                if (respawnChance == true)
                {
                    position.Set(j, k, 0f);
                    Instantiate(enviromentSpritesObj[numberOfSprite], position, Quaternion.identity);
                    numberOfSprite = Random.Range(0, enviromentSprites.Length);
                }
                respawnChance = (Random.value < chanceForNeutralEnviroment);

            }
        }
        

    }

    public void drawLevel(GameObject[] spritesObj)
    {
      
        int LenghtHelpX1 = Level.length;
        int LenghtHelpY = Level.length;


        if (MapType == "desert")                            // type of map 
        {
            Debug.Log(MapType);
            /////////////////////////////////////////////////////////////////////////////// acquiring objects from main tab
            spritesObj = new GameObject[centerMapSprites.Length];
            spritesObj[0] = centerMapSprites[0];
            spritesObj[1] = centerMapSprites[1];
            spritesObj[2] = centerMapSprites[2];
            spritesObj[3] = centerMapSprites[3];
            spritesObj[4] = centerMapSprites[4];
            spritesObj[5] = centerMapSprites[5];
            spritesObj[6] = centerMapSprites[6];
            spritesObj[7] = centerMapSprites[7];
            spritesObj[8] = centerMapSprites[8];
            spritesObj[9] = centerMapSprites[9];
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

                    Instantiate(spritesObj[1], pos, Quaternion.identity);
                }
                /////////////////////////////////////////////////////////////////////////////// corners
                else if (pos.x == -Level.length + 1 && pos.y == -Level.length + 1)
                {
                    Instantiate(spritesObj[6], pos, Quaternion.identity);
                }
                else if (pos.x == -Level.length + 1 && pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj[7], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1 && pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj[8], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1 && pos.y == -Level.length + 1)
                {
                    Instantiate(spritesObj[9], pos, Quaternion.identity);
                }
                /////////////////////////////////////////////////////////////////////////////// sides
                else if (pos.x == -Level.length + 1)
                {
                    Instantiate(spritesObj[4], pos, Quaternion.identity);
                }
                else if (pos.x == Level.length - 1)
                {
                    Instantiate(spritesObj[2], pos, Quaternion.identity);
                }
                else if (pos.y == -Level.length + 1)
                {
                    Instantiate(spritesObj[3], pos, Quaternion.identity);
                }
                else if (pos.y == Level.length - 1)
                {
                    Instantiate(spritesObj[5], pos, Quaternion.identity);
                }
                /////////////////////////////////////////////////////////////////////////////// center
                else
                    Instantiate(spritesObj[0], pos, Quaternion.identity);
            }

        }
    }
}
