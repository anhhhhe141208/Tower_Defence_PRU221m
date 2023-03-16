using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Manager>();
            }
            return instance;
        }
    }

    public int startingLives = 10;
    public int startingMoney = 100;
    public Text livesText;
    public Text moneyText;

    private int currentLives;
    private int currentMoney;

    private void Start()
    {
        currentLives = startingLives;
        currentMoney = startingMoney;
        UpdateLivesText();
        UpdateMoneyText();
        SpawnMonster();
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
    //----------------------------------------
    public MonsterFactory[] monsterFactories;
    public Transform[] spawnPoints;
    public Transform endPoint;

    private int _currentSpawnPoint = 0;


    private void SpawnMonster()
    {
        MonsterFactory factory = monsterFactories[Random.Range(0, monsterFactories.Length)];
        Transform spawnPoint = spawnPoints[_currentSpawnPoint];

        factory.CreateMonster(spawnPoint.position);

        //_currentSpawnPoint = (_currentSpawnPoint + 1) % spawnPoints.Length;
    }

}
