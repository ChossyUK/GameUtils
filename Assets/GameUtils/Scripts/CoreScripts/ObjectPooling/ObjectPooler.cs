using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    // Object pooling script to save on using the garbage collector

    #region Public Variables
    [Header("GameObject To Be Pooled")]
    public GameObject itemToBePooled;                   // GameObject you want to be stored in the object pool

    [Header("Number Of GameObjects To Be Pooled")]
    public int numberOfItems;                           // Number of gameobjects to be stored

    List<GameObject> pooledObjects;                     // A list to store the pooled gameobjects in
    #endregion

    #region Unity Base Methods
    void Start()
    {
        pooledObjects = new List<GameObject>();                             // Create a new list to store our pooled object in
        for (int i = 0; i < numberOfItems; i++)                             // Create a for loop and loop through our game objects until it reaches the max number of items to be pooled
        {
            GameObject obj = (GameObject)Instantiate(itemToBePooled);       // Create the pooled object
            obj.SetActive(false);                                           // Set the object to be inactive
            pooledObjects.Add(obj);                                         // Add the object to the list   
        }
    }
    #endregion

    #region User Methods
    public GameObject GetPooledObject()                                     // Create a function to get the pooled object
    {
        for (int i = 0; i < pooledObjects.Count; i++)                       // Create a loop to check if the objects we want are already active
        {
            if (!pooledObjects[i].activeInHierarchy)                        // Check if the item is or is not active
            {
                return pooledObjects[i];                                    // If not active we can use this object, so use the object
            }
        }
        GameObject obj = (GameObject)Instantiate(itemToBePooled);           // Check if we have enough pooled objects to fulfill our needs if not create a new object
        obj.SetActive(false);                                               // Set the object to be inactive
        pooledObjects.Add(obj);                                             // Add the object to the list
        return obj;                                                         // Return the new pooled object
    }
    #endregion

}
