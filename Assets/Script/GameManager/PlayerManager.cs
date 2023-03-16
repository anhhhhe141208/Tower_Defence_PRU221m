using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, IObserver
{
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

    public int startingLives = 10;
    public int startingMoney = 100;
    public Text livesText;
    public Text moneyText;

    private int currentLives;
    public int CurrentLives { get => currentLives;}

    private int currentMoney;
    public int CurrentMoney { get => currentMoney;}

    private void Start()
    {
        MonsterSubject.Instance.Attach(this);
        currentLives = startingLives;
        currentMoney = startingMoney;
        UpdateLivesText();
        UpdateMoneyText();
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
        currentLives -= amount;
        if (currentLives <= 0)
        {
            GameOver();
        }
        UpdateLivesText();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    public void SubtractMoney(int amount)
    {
        currentMoney -= amount;
        UpdateMoneyText();
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + currentLives;
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "Money: " + currentMoney;
    }

    private void GameOver()
    {
        // Game over logic
    }

    
}
