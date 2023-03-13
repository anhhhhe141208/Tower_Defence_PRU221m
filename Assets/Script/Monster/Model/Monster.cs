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

    private float currentHealth ;
    private Image healthBar;
    // Các behavior chung cua monster

    private void Start()
    {
        //healthBar = GetComponent<HealthBarHandler>().FillAmountImage;
        currentHealth = health;
    }
    public void Move()
    {
        // monster di chuyen den dich
        //flip sprite moi step
        this.transform.DOPath(path, 4, PathType.Linear);
            /*.SetLoops(1)
            .SetEase(ease)
            .OnStepComplete(FlipScpite);*/
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        hitAnimation();
        //healthBarGetDamge();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // xu li khi monster bi tieu diet
    }

    private void hitAnimation()
    {
        GetComponent<HandleAnimation>().monsterHitted();
    }

    private void healthBarGetDamge() 
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            currentHealth / health,
            Time.deltaTime * 10f);
    }

    // hanh vi dac biet cua tung loai monster
    public abstract void SpecialAbility();

    
}
