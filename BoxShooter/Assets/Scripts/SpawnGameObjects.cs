using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
    // public variables
    public float secondsBetweenSpawning = 0.1f;
    public float xMinRange = -25.0f;
    public float xMaxRange = 25.0f;
    public float yMinRange = 8.0f;
    public float yMaxRange = 25.0f;
    public float zMinRange = -25.0f;
    public float zMaxRange = 25.0f;
    
    public GameObject[] spawnObjects;
    public GameObject bomberObject;

    private float nextSpawnTime;

    // Count-down timer until the next bomber
    // TODO, NOTE :: Should we add some console logging to see the tracking?
    private float bomberCDTimer = 2f;
    private GameObject activeBomber = null;

    // Use this for initialization
    void Start ()
    {
        // determine when to spawn the next object
        nextSpawnTime = Time.time+secondsBetweenSpawning;
    }
  
    // Update is called once per frame
    void Update ()
    {
        // exit if there is a game manager and the game is over
        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver)
                return;
        }

        // if time to spawn a new game object
        if (Time.time  >= nextSpawnTime) {
            // Spawn the game object through function below
    //        MakeThingToSpawn ();

            // determine the next time to spawn the object
            nextSpawnTime = Time.time+secondsBetweenSpawning;
        }	

        if (bomberCDTimer <= 0.0) {
            activeBomber = CreateBomber();

            bomberCDTimer = Random.Range(3.0f, 6.0f);
            //Debug.Log("New Bomber CDT :: " + bomberCDTimer);
        } else {
            bomberCDTimer -= Time.deltaTime;
            //Debug.Log("Bomber timer: " + bomberCDTimer);
        }

    }

    Vector3 RandomPosition () {
        Vector3 spawnPosition;
             
        // get a random position between the specified ranges
        spawnPosition.x = Random.Range (xMinRange, xMaxRange);
        spawnPosition.y = Random.Range (yMinRange, yMaxRange);
        spawnPosition.z = Random.Range (zMinRange, zMaxRange);

        return spawnPosition;
    }
    
    void MakeThingToSpawn ()
    {
        Vector3 spawnPosition = RandomPosition();

        // determine which object to spawn
        int objectToSpawn = Random.Range (0, spawnObjects.Length);

        // actually spawn the game object
        GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
    }
    
    
    GameObject CreateBomber () {
        Vector3 spawnPosition = RandomPosition();
        
        GameObject bomber = Instantiate (bomberObject, spawnPosition, transform.rotation) as GameObject;

        bomber.transform.parent = gameObject.transform;

        return bomber;
    }
   
}
