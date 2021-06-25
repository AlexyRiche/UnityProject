using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wallPrefab;
    public Transform spawnTop;
    public Transform spawnBot;
    
    public float spawnDelay;
    public float spawnTime;
    public bool stopSpawn = false;


    void Start()
    {
        InvokeRepeating("spawnWall", spawnTime, spawnDelay);
    }
    void spawnWall() {
            if (Random.Range(0, 2) == 1) { // spwan wall top
                GameObject wall = Instantiate(wallPrefab, spawnTop.position, spawnTop.rotation);
                wall.transform.localScale = new Vector3(1.5f, Random.Range(3,8), 1);
                float height = (float)wall.GetComponent<SpriteRenderer>().bounds.size.y;
                wall.transform.position = new Vector3(spawnTop.position.x, spawnTop.position.y - height/2, spawnTop.position.z);
            } else {
                GameObject wall = Instantiate(wallPrefab, spawnBot.position, spawnBot.rotation);
                wall.transform.localScale = new Vector3(1.5f, Random.Range(3,8), 1);
                float height = (float)wall.GetComponent<SpriteRenderer>().bounds.size.y;
                wall.transform.position = new Vector3(spawnBot.position.x, spawnBot.position.y + height/2, spawnBot.position.z);
            }
            if (stopSpawn) {
                CancelInvoke("spawnWall");
            }
        }
    // Update is called once per frame
    void Update() {
        
    }
    
}
