using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMonsterFactory : MonoBehaviour
{
    // Prefab cua monster
    public GameObject monsterPrefab;

    // Các thông s? c?a monster
    public int health = 100;
    public int speed = 5;

    private void Start()
    {
        Vector3 a = new Vector3(0, 0, 0);
        CreateMonster(a,transform);
    }
    public IMonster CreateMonster(Vector3 startPosition, Transform target)
    {
        // Tao mot doi tuonng monster tu prefab
        GameObject monsterObject = Instantiate(monsterPrefab, startPosition, Quaternion.identity);

        // thiet lap thong so cho loai monster nay
        var goblinMonster = monsterObject.GetComponent<Goblin>();
        goblinMonster.health = health;  
        goblinMonster.speed = speed;

        return goblinMonster;
    }
}
