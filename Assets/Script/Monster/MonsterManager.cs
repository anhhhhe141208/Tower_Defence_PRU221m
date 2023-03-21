using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // Factory cua monster goblin
    public MonsterFactory factory;

    // Vi tri bat dau cua monster
    public Vector3 startPosition;

    private List<Monster> monster = new List<Monster>();
    void Start()
    {
        // tao monster = monster factory
        //monster = (Monster)factory.CreateMonster(startPosition);

        // goi hanh vi dac biet cua monster
        //monster.SpecialAbility();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(MonsterSubject.Instance._observers.Count);
        if (Input.GetMouseButtonDown(0))
        {
            monster[Random.Range(0, monster.Count)].TakeDamage(5);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnMonster();
        }
    }

    //----------------------------------------
    public MonsterFactory[] monsterFactories;
    public Transform[] spawnPoints;
    private void SpawnMonster()
    {
        MonsterFactory factory = monsterFactories[Random.Range(0, monsterFactories.Length)];
        Transform spawnPoint = spawnPoints[0];

        monster.Add((Monster)factory.CreateMonster(spawnPoint.position));

        //_currentSpawnPoint = (_currentSpawnPoint + 1) % spawnPoints.Length;
    }
}
