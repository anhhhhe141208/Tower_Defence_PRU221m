using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    private List<Monster> monsterList = new List<Monster>();
    public float spawnTime = 1f; // th?i gian gi?a các l?n sinh
    public float timerWave = 0f;
    private Monster monster;
    void Start()
    {
    }

    void Update()
    {
        StartCoroutine(SpawnMonster());
    }

    //----------------------------------------
    public MonsterFactory[] monsterFactories;
    MonsterFactory factory;
    private IEnumerator SpawnMonster()
    {
        timerWave += Time.deltaTime;
        if (timerWave > spawnTime) // n?u th?i gian trôi qua v??t quá th?i gian gi?a các l?n sinh
        {
            for (int i = 0; i < 5; i++)
            {
                factory = monsterFactories[Random.Range(0, 3)];
                monster = (Monster)factory.CreateMonster();
                if(monster != null)
                {
                    monsterList.Add(monster);
                }
                timerWave = 0f; // reset timer
                yield return new WaitForSeconds(5f);
            }
            
        }
    }
}
