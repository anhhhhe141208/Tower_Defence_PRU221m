using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMonsterFactory : MonoBehaviour
{
    // Prefab c?a monster
    public GameObject monsterPrefab;

    // C�c th�ng s? c?a monster
    public int health = 100;
    public int speed = 5;
    public int damage = 20;

    public IMonster CreateMonster(Vector3 startPosition, Transform target)
    {
        // T?o m?t ??i t??ng monster t? prefab
        GameObject monsterObject = Instantiate(monsterPrefab, startPosition, Quaternion.identity);

        // Thi?t l?p c�c th�ng s? c?a monster
        var monster = monsterObject.GetComponent<Monster>();
        monster.health = health;
        monster.speed = speed;

        // Thi?t l?p h�nh vi ??c bi?t cho lo?i monster n�y
       /* var goblinMonster = monsterObject.GetComponent<GoblinMonster>();
        // goblin monster ch?a c�
        goblinMonster.target = target;
        goblinMonster.damage = damage;*/

        return monster;
    }
}
