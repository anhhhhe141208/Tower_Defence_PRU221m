using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerFactory : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract GameObject CreateTower(Vector2 position);
}
