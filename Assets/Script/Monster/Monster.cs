using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour,IMonster
{
    // C�c th�ng s? c?a monster
    public int health;
    public int speed;

    // C�c h�nh vi chung c?a monster
    public void Move()
    {
        // Di chuy?n monster ??n ?�ch
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
        // X? l� khi monster b? ti�u di?t
    }

    // H�nh vi ??c bi?t c?a t?ng lo?i monster
    public abstract void SpecialAbility();
}
