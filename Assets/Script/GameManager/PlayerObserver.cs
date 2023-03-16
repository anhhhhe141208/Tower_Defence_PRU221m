using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObserver : MonoBehaviour,IObserver
{

    public void OnMonsterDamaged(Monster monster, int damage)
    {
        // do nothing
    }

    public void OnMonsterKilled(Monster monster)
    {
        Manager.Instance.AddMoney(monster.killReward);
        Debug.Log("Earned " + monster.killReward);
    }

    public void OnMonsterReachedEnd(Monster monster)
    {
        if (Manager.Instance.CurrentLives <= 0)
        {
            // Player loses the game
            Debug.Log("Game Over");
            return;
        }
        Manager.Instance.SubtractLife(1);
        
    }
}
