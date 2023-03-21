using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IObserver
{
    public HealBar healthBar;
    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
            }
            return instance;
        }
    }
    public List<GameObject> monsterList = new List<GameObject>();
    public int startingPoint = 0;
    public int startingLives = 100;
    public int startingMoney = 100;
    public Text livesText;
    public Text moneyText;
    public Text pointText;

    private int currentLives;
    private int currentPoint;
    private int currentMoney;
    public int CurrentPoint { get => currentPoint;}
    public int CurrentMoney { get => currentMoney;}
    public int CurrentLives { get => currentLives; set => currentLives = value; }

    private void Start()
    {
        MonsterSubject.Instance.Attach(this);
        CurrentLives = startingLives;
        currentMoney = startingMoney;
        currentPoint = startingPoint;
       // UpdateLivesText();
        UpdateMoneyText();
        healthBar.SetMaxHealth(startingLives);
    }

    public void OnMonsterDamaged(Monster monster, int damage)
    {
        // do nothing
    }

    public void OnMonsterKilled(Monster monster)
    {
        AddMoney(monster.killReward);
    }

    public void OnMonsterReachedEnd(Monster monster)
    {
        SubtractLife(1);
    }

    public void SubtractLife(int amount)
    {
        CurrentLives -= amount;

        if (CurrentLives <= 0)
        {
            GameOver();
        }
        healthBar.SetHealth(CurrentLives);   
        //UpdateLivesText();
    }

    public void AddMoney(int amount)
    {
        currentPoint += amount;
        currentMoney += amount;
        UpdateMoneyText();
        
    }

    public void SubtractMoney(int amount)
    {
        currentPoint -= amount;
        currentMoney -= amount;
        UpdateMoneyText();
    }

    
    private void UpdateMoneyText()
    {
        moneyText.text = " " + currentMoney;
        pointText.text = "Points: " + currentPoint;

    }

    private void GameOver()
    {
        if (GameOverScreen != null)
        {
            GameOverScreen gameOverScreen = GameOverScreen.GetComponent<GameOverScreen>();
            if (gameOverScreen != null)
            {
                GameOverScreen.Setup(maxPlatform);
            }
        }


        // Game over logic
    }


}
