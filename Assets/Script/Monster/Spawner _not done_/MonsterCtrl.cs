using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : LamMonoBehaviour
{
    [SerializeField] protected MonsterSpawner enemySpawner;
    public MonsterSpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected SpawnPoint spawnPoints;
    public SpawnPoint SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<SpawnPoint>();
        Debug.Log("load spawnPoints");
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponent<MonsterSpawner>();
    }
}
