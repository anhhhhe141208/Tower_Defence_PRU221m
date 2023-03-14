using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;

    public override void shoot()
    {
        if (currentTarget != null)
        {
            Enemy enemyScript = currentTarget.GetComponent<Enemy>();
            enemyScript.takeDamage(damage);

            GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
        }
    }
}
