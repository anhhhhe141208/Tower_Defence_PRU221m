using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerFactory : TowerFactory

{
    public GameObject towerPrefab;
    public Vector3 startPosition;
    public override Tower CreateTower()
    {
        /*GameObject monsterObject = Instantiate(towerPrefab, startPosition, Quaternion.identity);*/

        

        return new BasicTower();
    }

    public void Start()
    {
        
    }
}