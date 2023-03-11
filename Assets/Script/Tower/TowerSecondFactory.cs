using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSecondFactory : TowerFactory
{
    public GameObject TowerSecondPrefab;

    public override GameObject CreateTower(Vector2 position)
    {
        var tower = Instantiate(TowerSecondPrefab, position, Quaternion.identity);
        return tower;
    }
}
