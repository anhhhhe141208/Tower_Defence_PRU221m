using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMonsterFactory : MonsterFactory
{

    // Các thông s? c?a monster
    public float health = 100;
    public float speed = 5;
    public int killReward = 5;

    public override IMonster CreateMonster()
    {
        try
        {
            // Tao mot doi tuonng monster tu prefab
            GameObject monsterObject = BunnyPool.Instance.GetGameObject();
            // thiet lap thong so cho loai monster nay
            var bunnyMonster = monsterObject.GetComponent<Bunny>();
            bunnyMonster.health = health;
            bunnyMonster.speed = speed;
            bunnyMonster.killReward = killReward;

            return bunnyMonster;
        } catch
        {
            return null;
        }
    }
}
