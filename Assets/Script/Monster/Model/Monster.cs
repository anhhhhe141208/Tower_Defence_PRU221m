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
    private SpriteRenderer spriteRenderer;
    // Các behavior chung cua monster
    public void Move()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        // monster di chuyen den dich
        //flip sprite moi step
        this.transform.DOPath(path, 4, PathType.Linear);
            /*.SetLoops(1)
            .SetEase(ease)
            .OnStepComplete(FlipScpite);*/
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

    private void FlipScpite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
