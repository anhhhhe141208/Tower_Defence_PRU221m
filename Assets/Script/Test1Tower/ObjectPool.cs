using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 10;

    [SerializeField] private GameObject bullet;

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
            Console.WriteLine("vao tao bullet");
            /*GameObject obj = Instantiate(bullet, barrel.position, pivot.rotation);*/
            GameObject obj = Instantiate(bullet);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        
    }

    public GameObject GetGameObject()
    {
        Console.WriteLine("vao ham lay bullet");
        for (int i=0; i < pooledObjects.Count; i++)
        {
            Console.WriteLine(pooledObjects[i].activeInHierarchy);
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        
        return null;
    }

   
}
