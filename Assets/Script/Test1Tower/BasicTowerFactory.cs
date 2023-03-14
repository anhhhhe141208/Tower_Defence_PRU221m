using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTowerFactory : TowerFactory
{
    public override Tower CreateTower()
    {
        return new BasicTower();
    }
}