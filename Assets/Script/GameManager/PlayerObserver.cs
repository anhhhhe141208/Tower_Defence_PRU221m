using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour,IObserver
{
    private int _health = 3;
    private int _money = 0;

    public void OnMonsterDamaged(Monster monster, int damage)
    {
    }

    public void OnMonsterKilled(Monster monster)
    {
        _money += monster.killReward;
        Debug.Log("Earned " + monster.killReward);
    }

    public void OnMonsterReachedEnd(Monster monster)
    {
        _health--;
        if (_health <= 0)
        {
            // Player loses the game
            Debug.Log("Game Over");
        }
    }
}
