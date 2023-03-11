using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerThirFactory : TowerFactory
{
    public GameObject TowerThirPrefab;

    public override GameObject CreateTower(Vector2 position)
    {
        var tower = Instantiate(TowerThirPrefab, position, Quaternion.identity);
        return tower;
    }
}
