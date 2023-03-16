using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMonsterFactory : MonsterFactory
{
    // Prefab cua monster
    public GameObject monsterPrefab;

    // Các thông s? c?a monster
    public float health = 100;
    public float speed = 5;
    public int killReward = 5;

    public override IMonster CreateMonster(Vector3 startPosition)
    {
        // Tao mot doi tuonng monster tu prefab
        GameObject monsterObject = Instantiate(monsterPrefab, startPosition, Quaternion.identity);

        // thiet lap thong so cho loai monster nay
        var bunnyMonster = monsterObject.GetComponent<Bunny>();
        bunnyMonster.health = health;
        bunnyMonster.speed = speed;
        bunnyMonster.killReward = killReward;

        return bunnyMonster;
    }
}
