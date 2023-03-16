using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : Spawner
{
    private static MonsterSpawner instance;
    public static MonsterSpawner Instance { get => instance; }

    public static string monsterName = "";

    protected override void Awake()
    {
        base.Awake();
        if (MonsterSpawner.instance != null) Debug.LogError("Enemy Spawner Existed");
        MonsterSpawner.instance = this;
    }
}
