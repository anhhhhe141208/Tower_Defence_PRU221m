using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObserver : MonoBehaviour, IObserver
{
    public void OnMonsterDamaged(Monster monster, int damage)
    {
        //monster.TakeDamage(damage);
    }

    public void OnMonsterKilled(Monster monster)
    {
        // do nothing
    }

    public void OnMonsterReachedEnd(Monster monster)
    {
        // do nothing
    }
}
