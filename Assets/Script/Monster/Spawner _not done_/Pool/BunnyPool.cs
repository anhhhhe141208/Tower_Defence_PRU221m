using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyPool : MonoBehaviour
{
    private static BunnyPool instance;
    public static BunnyPool Instance { get => instance; }
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
                pooledObjects[i].SetActive(true);
                pooledObjects[i].transform.position = pooledObjects[i].GetComponent<Monster>().path[0];
                pooledObjects[i].GetComponent<Monster>().Move();
                return pooledObjects[i];
            }
        }
        return null;
    }
}
