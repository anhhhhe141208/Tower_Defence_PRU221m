using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Monster : MonoBehaviour, IMonster
{
    // Các thông so cua monster
    public float health;
    public float speed;
    public Vector3[] path = new Vector3[4];

    private float currentHealth;
    private Image healthBar;
    private Tween tween;
    // Các behavior chung cua monster

    private void Start()
    {
        healthBar = GetComponentInChildren<HealthBarHandler>().FillAmountImage;
        currentHealth = health;
    }
    public void Move()
    {
        // monster di chuyen den dich
        this.transform
            .DOPath(path, 4, PathType.Linear)
            .OnWaypointChange(MyWaypointChangeHandler)
            .OnComplete(reachTarget);
    }

    // take dmg -> -hp, run animation -> die
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hitAnimation();
        Debug.Log(currentHealth + "-" + health);
        healthBarGetDamge();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    // doing
    public void MyWaypointChangeHandler(int waypointIndex)
    {
        // N?u Tween ?i qua waypoint th? hai
        if (waypointIndex + 1 >= path.Length)
        {
            var direction = (path[waypointIndex] - path[waypointIndex]).normalized;
            if (direction.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                Debug.Log(true);
            }
        }
    }
    // xu li khi monster bi tieu diet
    public void Die()
    {
        //temp
        Destroy(gameObject);

        //To Do: add: + tien
    }

    // xu li khi monster den dich
    public void reachTarget() 
    {
        //temp
        Destroy(gameObject);

        // To Do : - tim <3 
    }

    private void hitAnimation()
    {
        GetComponent<HandleAnimation>().monsterHitted();
    }

    private void healthBarGetDamge() 
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            currentHealth / health,
            10f);
    }

    // hanh vi dac biet cua tung loai monster
    public abstract void SpecialAbility();

    
}
