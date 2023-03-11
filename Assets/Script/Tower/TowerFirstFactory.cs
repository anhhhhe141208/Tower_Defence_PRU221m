using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFirstFactory : TowerFactory
{
    public GameObject TowerFirstPrefab;

    public override GameObject CreateTower(Vector2 position)
    {
        var tower = Instantiate(TowerFirstPrefab, position, Quaternion.identity);
        return tower;
    }
}
