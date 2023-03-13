using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : IMonster
{
    // C�c th�ng so cua monster
    public int health;
    public int speed;

    // C�c behavior chung cua monster
    public void Move()
    {
        // monster di chuyen den dich
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // xu li khi monster bi tieu diet
    }

    // hanh vi dac biet cua tung loai monster
    public abstract void SpecialAbility();
}
