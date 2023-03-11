using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TowerFactory TowerFactory;
    

    private void Start()
    {
        // Create tower A
        var towerA = TowerFactory.CreateTower(new Vector2(0, 0));

        // Get shooter component of tower A
        var shooterA = towerA.GetComponent<IShooter>();

       

        
    }
}
