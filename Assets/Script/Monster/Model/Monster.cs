using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour, IMonster
{
    // Các thông so cua monster
    public int health;
    public int speed;
    public Vector3[] path = new Vector3[4];
    public Tween t;

    // Các behavior chung cua monster
    public void Move()
    {
        // monster di chuyen den dich
        t = this.transform.DOPath(path, 4, PathType.Linear);
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
