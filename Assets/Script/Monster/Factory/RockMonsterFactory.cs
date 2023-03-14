using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMonsterFactory : MonoBehaviour
{
    // Prefab cua monster
    public GameObject monsterPrefab;

    // Các thông s? c?a monster
    public float health = 100;
    public float speed = 5;

    public IMonster CreateMonster(Vector3 startPosition)
    {
        // Tao mot doi tuonng monster tu prefab
        GameObject monsterObject = Instantiate(monsterPrefab, startPosition, Quaternion.identity);

        // thiet lap thong so cho loai monster nay
        var rockMonster = monsterObject.GetComponent<Rock>();
        rockMonster.health = health;
        rockMonster.speed = speed;

        return rockMonster;
    }
}
