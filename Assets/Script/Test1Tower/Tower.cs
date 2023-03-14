using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] public float damage;
    [SerializeField] private float timeBetweenShots;
    private float nextTimeToShoot;
    public GameObject currentTarget;

    public abstract void shoot();

    void Start()
    {
        nextTimeToShoot = Time.time;
    }

    private void updateNeartestEnemy()
    {
        GameObject currentNearstEnemy = null;
        float distance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies.enemies)
        {
            if (enemy != null)
            {
                float _distance = (transform.position - enemy.transform.position).magnitude;

                if (_distance < distance)
                {
                    distance = _distance;
                    currentNearstEnemy = enemy;
                }
            }
        }

        if (distance <= range)
        {
            currentTarget = currentNearstEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }

    void Update()
    {
        updateNeartestEnemy();
        if (Time.time >= nextTimeToShoot)
        {
            if (currentTarget != null)
            {
                shoot();
                nextTimeToShoot = Time.time + timeBetweenShots;
            }
        }
    }
}
