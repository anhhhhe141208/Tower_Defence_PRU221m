using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterPool : MonoBehaviour
{
    private static MonsterPool instance;
    public static MonsterPool Instance { get => instance; }

    private List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool = 10;

    [SerializeField] protected GameObject prefab;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.parent = this.gameObject.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetGameObject()
    {
        for (int i=0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        Debug.Log(pooledObjects.Count);
        return null;
    }

   
}