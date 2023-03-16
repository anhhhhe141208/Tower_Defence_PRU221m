using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    void OnMonsterDamaged(Monster monster, int damage);
    void OnMonsterKilled(Monster monster);
    void OnMonsterReachedEnd(Monster monster);
}
