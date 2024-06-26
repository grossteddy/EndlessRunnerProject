using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] int poolSize;
    [SerializeField] GameObject prefab;
    [SerializeField] List<PoolingObject> pool = new List<PoolingObject>();



    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(SpawnNewObject());
            
        }
    }

    private PoolingObject SpawnNewObject()
    {
        GameObject spawned = Instantiate(prefab, transform);
        PoolingObject spawnedPoolingObj;

        spawned.TryGetComponent<PoolingObject>(out spawnedPoolingObj);
        if(spawnedPoolingObj == null)
        {
            spawnedPoolingObj = spawned.AddComponent<PoolingObject>();
        }
        spawnedPoolingObj.Bind(this);
        spawned.SetActive(false);
        return spawnedPoolingObj;

    }


    public GameObject Pull(Vector3 position,Quaternion rotation)
    {
        GameObject pulled;
        PoolingObject pulledPooliongObj = null;
        if (pool.Count > 0)
        {
            pulledPooliongObj = pool[0];
            pulled = pulledPooliongObj.gameObject;
            pool.RemoveAt(0);
        }
        else
        {

            //if the pool is empty we fall back to instantiation
            pulledPooliongObj = SpawnNewObject();
            pulled = pulledPooliongObj.gameObject;  
        }

        pulled.SetActive(true);
        pulled.transform.position = position;
        pulled.transform.rotation = rotation;
        pulled.transform.SetParent(null);
        pulledPooliongObj.OnPulled();
        return pulled;
    }


    public GameObject Pull(Vector3 position, Quaternion rotation,Space space)
    {
        GameObject pulled;
        PoolingObject pulledPooliongObj = null;
        if (pool.Count > 0)
        {
            pulledPooliongObj = pool[0];
            pulled = pulledPooliongObj.gameObject;
            pool.RemoveAt(0);
        }
        else
        {

            //if the pool is empty we fall back to instantiation
            pulledPooliongObj = SpawnNewObject();
            pulled = pulledPooliongObj.gameObject;
        }
        pulled.SetActive(true);

        if (space == Space.Self) 
        {
            pulled.transform.localPosition = position;
            pulled.transform.localRotation = rotation;
        }
        else
        {
            pulled.transform.position = position;
            pulled.transform.rotation = rotation;
           
        }

        pulled.transform.SetParent(null);
        pulledPooliongObj.OnPulled();
        return pulled;
    }

    public void Return(GameObject toReturn)
    {
        PoolingObject poolingObj = toReturn.GetComponent<PoolingObject>();
        if (!poolingObj) return;

        pool.Add(poolingObj);
        poolingObj.OnReturn();
        toReturn.transform.SetParent(transform);
        toReturn.transform.position = Vector3.zero;
        toReturn.transform.rotation = Quaternion.identity;
        toReturn.SetActive(false);
    }
}
