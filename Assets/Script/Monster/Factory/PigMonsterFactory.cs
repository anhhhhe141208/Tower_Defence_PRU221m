using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMonsterFactory : MonsterFactory
{
    // C?c th?ng s? c?a monster
    public float health = 100;
    public float speed = 5;
    public int killReward = 5;

    public override IMonster CreateMonster()
    {
        try
        {
            // Tao mot doi tuonng monster tu prefab
            GameObject monsterObject = PigPool.Instance.GetGameObject();
            // thiet lap thong so cho loai monster nay
            var pigMonster = monsterObject.GetComponent<Pig>();
            pigMonster.health = health;
            pigMonster.speed = speed;
            pigMonster.killReward = killReward;

            return pigMonster;
        } catch
        {
            return null;
        }
        
    }
}