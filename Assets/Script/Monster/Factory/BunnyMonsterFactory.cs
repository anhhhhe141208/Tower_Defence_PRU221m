using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMonsterFactory : MonoBehaviour
{
    // Prefab cua monster
    public GameObject monsterPrefab;

    // C�c th�ng s? c?a monster
    public float health = 100;
    public float speed = 5;

    public IMonster CreateMonster(Vector3 startPosition)
    {
        // Tao mot doi tuonng monster tu prefab
        GameObject monsterObject = Instantiate(monsterPrefab, startPosition, Quaternion.identity);

        // thiet lap thong so cho loai monster nay
        var bunnyMonster = monsterObject.GetComponent<Bunny>();
        bunnyMonster.health = health;
        bunnyMonster.speed = speed;

        return bunnyMonster;
    }
}
