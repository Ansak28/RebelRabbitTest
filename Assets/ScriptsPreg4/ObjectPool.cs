using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake() 
    {
        SharedInstance = this;
    }
    private void Start() 
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i<amountToPool;i++)
        {
            tmp= Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        
        for(int i = 0; i<amountToPool;i++)
        {
            if(pooledObjects.Count > 0)
            {
            if(!pooledObjects[i].activeInHierarchy)
            {
                GameObject pooledObject = pooledObjects[i];
                pooledObjects.RemoveAt(i);
                return pooledObject;
            }
            }
            
        }
        return null;
    }
}
