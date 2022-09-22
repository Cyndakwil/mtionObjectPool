using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjs;
    public GameObject pooledPrefab; // which object to instantiate
    public int poolSize;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjs = new List<GameObject>();
        GameObject obj;
        for (int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(pooledPrefab);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
    }

    public GameObject GetPooledObject() // returns first inactive object in pool
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }

        return null; // no active objects left
    }
}