using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceTowerFactory : Tower
{
    // Start is called before the first frame update
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;

    public GameObject towerPrefab;
    public Vector3 startPosition = new Vector3(3, 3, 0);
    public override void createTower()
    {
        GameObject towerObj = Instantiate(towerPrefab, startPosition, Quaternion.identity);
    }

    public override void shoot()
    {
        if (currentTarget != null)
        {
            Console.WriteLine("vao ham shoot");

            /*GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);*/
            GameObject bullet = ObjectPoolAdvance.instance.GetGameObject();

            if (bullet != null)
            {
                bullet.transform.position = barrel.transform.position;
                bullet.transform.rotation = pivot.transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    private void Start()
    {
    }
}
