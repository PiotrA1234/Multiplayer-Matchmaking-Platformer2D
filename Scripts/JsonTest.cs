using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class NewBehaviourScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(5f, 0f, 0f);
        playerData.health = 90;
        string json = JsonUtility.ToJson(playerData);
       // Debug.Log(json);
        // File.WriteAllText(Application.dataPath + "/savefile.json", json);
        File.ReadAllText(Application.dataPath + "/savefile.json");
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }

    public class PlayerData {
       public Vector3 position;
        public int health;
    }
}
