using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMonsterFactory : MonsterFactory
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
        GameObject monsterObject = RockPool.Instance.GetGameObject();
        monsterObject.transform.position = startPosition;
        // thiet lap thong so cho loai monster nay
        var rockMonster = monsterObject.GetComponent<Rock>();
        rockMonster.health = health;
        rockMonster.speed = speed;
        rockMonster.killReward = killReward;

        return rockMonster;
    }
}
