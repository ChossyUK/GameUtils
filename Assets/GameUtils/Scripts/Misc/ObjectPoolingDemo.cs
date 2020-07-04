using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingDemo : MonoBehaviour
{
    // Maximum amout of objects to be pooled
    public int maxObjects = 0;

    // Number of objects spawned
    public int spawnCount = 0;

    // Pooled object spawn time
    public float spawnTime = 1f;

    // The delay before resetting the pooled objects
    public float respawnDelay = 1f;

    // Maximum horizontal spawn position
    public float maxX;

    // Maximum vertical spawn position
    public float maxY;

    // The object pool
    public ObjectPooler objectPool;

    // Float for a timer
    private float timer = 0;

    private GameObject[] gameObjects;

    void Update()
    {

        // Start the timer
        timer += Time.deltaTime;

        // Check if the timer value is greater the the spawn time
        if (timer > spawnTime)
        {
            // Check if the number of spawned objects is less than the maximum object count
            if (spawnCount < maxObjects)
            {
                // Spawn new object
                SpawnItem();

                // Reset the timer
                timer = 0;
            }
        }

        // Check if we have reach the maximum amout of spawned bojects
        if (spawnCount >= maxObjects)
        {
            // Run the reset object pool coroutine
            StartCoroutine(ResetObjectPool());
        }
    }

    void SpawnItem()
    {
        // Check if the number of spawned objects is less than the maximum object count
        if (spawnCount < maxObjects)
        {
            // Create a new random position
            Vector2 newPos = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            // Get an object from the object pool
            GameObject item = objectPool.GetPooledObject();

            // Set its position
            item.transform.position = newPos;

            // Set it to be active
            item.SetActive(true);
               
            // Increase the spawn count
            spawnCount++;
        }
    }

    IEnumerator ResetObjectPool()
    {
        // Null the array
        gameObjects = null;

        // Wait for X amount of second
        yield return new WaitForSeconds(respawnDelay);

        // Get all the game object with the PooledObject tag
        gameObjects = GameObject.FindGameObjectsWithTag("PooledObject");

        // Loop through and deactivate the pooled objects
        for (int i = 0; i < gameObjects.Length; i++)
        {    
            gameObjects[i].SetActive(false);
            i++;
        }
       
        // Reset the timer
        timer = 0;

        // Reset the spawn count
        spawnCount = 0;
    }
}
