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
    public Vector3[] path = new Vector3[15];
    public GameObject ObjectListWavePoint;
    private List<GameObject> wavePointList = new List<GameObject>();

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
        for (int i = 0; i < 15; i++)
        {
            Transform child = ObjectListWavePoint.transform.GetChild(i);
            if (child != null)
            {
                wavePointList.Add(ObjectListWavePoint.transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < wavePointList.Count; i++)
        {
            path[i] = wavePointList[i].transform.position;
        }
    }
    
    public void Move()
    {
        if (this.gameObject.activeInHierarchy)
        {
            // monster di chuyen den dich
            this.transform
            .DOPath(path, speed, PathType.Linear)
            .SetSpeedBased(true)
            .OnWaypointChange(MyWaypointChangeHandler)
            .OnComplete(reachEnd);
        }
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

    // observer
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

    //-------------
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
    //-------------------
    public void resetMonster()
    {
        currentHealth = health;
        transform.DOKill();
        transform.position = path[0];
        
    }
    //-----------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            TakeDamage(bullet.damage);
        }
    }

}
