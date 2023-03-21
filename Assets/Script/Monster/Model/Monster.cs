using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public abstract class Monster : MonoBehaviour, IMonster, IObserver
{
    // public Score score;
    // Các thông so cua monster
    public float health;
    public float speed;
    public int killReward;
    private Vector3[] path = new Vector3[10];

    public float currentHealth;
    private Image healthBar;
    private Tween tween;
    // Các behavior chung cua monster

    private void Start()
    {
        // set health bar
        healthBar = GetComponentInChildren<HealthBarHandler>().FillAmountImage;
        currentHealth = health;
        // flip sprite to right
        this.GetComponent<SpriteRenderer>().transform.DOScaleX(1, 0);
    }

    private void Awake()
    {
        // set path
        PlayerManager.Instance.monsterList.Add(this.gameObject);
        path[0] = new Vector3(-16, 5, 0);
        path[1] = new Vector3(-10, 5, 0);
        path[2] = new Vector3(-10, -3, 0);
        path[3] = new Vector3(-15, -3, 0);
        path[4] = new Vector3(-15, -5, 0);

        path[5] = new Vector3(10, -5, 0);
        path[6] = new Vector3(10, 5, 0);
        path[7] = new Vector3(13, 5, 0);
        path[8] = new Vector3(13, -2, 0);
        path[9] = new Vector3(15, -2, 0);
        Move();
    }

    public void Move()
    {
        // monster di chuyen den dich
        this.transform
            .DOPath(path, 15, PathType.Linear)
            .OnWaypointChange(MyWaypointChangeHandler)
            .OnComplete(reachEnd);
    }
    public void reachEnd()
    {
        Debug.Log("1");
        MonsterSubject.Instance.Attach(this);
        MonsterSubject.Instance.NotifyOnMonsterReachedEnd(this);
        MonsterSubject.Instance.Detach(this);
        Debug.Log("1-end");
    }
    // take dmg -> -hp, run animation -> die
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hitAnimation();
        healthBarGetDamge();
        if (currentHealth <= 0)
        {
            MonsterSubject.Instance.Attach(this);
            MonsterSubject.Instance.NotifyOnMonsterKilled(this);
            MonsterSubject.Instance.Detach(this);
        }
        //Debug.Log(this.GetType() + "health: " + currentHealth);
    }
    // doing
    public void MyWaypointChangeHandler(int waypointIndex)
    {
        // N?u Tween ?i qua waypoint th? hai
        if (waypointIndex + 1 <= path.Length - 1)
        {
            var direction = (path[waypointIndex] - path[waypointIndex + 1]).normalized;
            if (direction.x > 0)
            {
                //Debug.Log("turn left");
                this.GetComponent<Animator>().transform.DOScaleX(1, 0);
            }
            else 
            {
                //Debug.Log("turn right");
                this.GetComponent<Animator>().transform.DOScaleX(-1, 0);
            }
        }
    }

    // hanh vi dac biet cua tung loai monster
    public abstract void SpecialAbility();

    public void OnMonsterDamaged(Monster monster, int damage)
    {
        // do nothing
    }

    public void OnMonsterKilled(Monster monster)
    {  
        Die();
    }

    public void OnMonsterReachedEnd(Monster monster)
    {
        reachTarget();
    }

    public void Die()
    {
        resetMonster();
        // temp
        this.gameObject.SetActive(false);
        //To Do: remove khoi Monster Object Pool 
    }

    public void reachTarget()
    {
        resetMonster();
        // temp
        this.gameObject.SetActive(false);
        //To Do: remove khoi Monster Object Pool 
    }

    private void hitAnimation()
    {
        GetComponentInChildren<HandleAnimation>().monsterHitted();
    }

    private void healthBarGetDamge()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount,
            currentHealth / health,
            10f);
    }

    public void resetMonster()
    {
        currentHealth = health;
        //transform.position = path[0];
        transform.DOPause();
    }
}
