using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour,IMonster
{
    // Các thông s? c?a monster
    public int health;
    public int speed;

    // Các hành vi chung c?a monster
    public void Move()
    {
        // Di chuy?n monster ??n ?ích
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
        // X? lý khi monster b? tiêu di?t
    }

    // Hành vi ??c bi?t c?a t?ng lo?i monster
    public abstract void SpecialAbility();
}
