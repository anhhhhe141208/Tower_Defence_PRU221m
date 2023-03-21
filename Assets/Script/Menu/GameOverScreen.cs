using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text finalscoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
       
        finalscoreText.text = scoreText.text;
        scoreText.gameObject.SetActive(false);

    }
    public void Restart()
    {
        Time.timeScale = 1f;
        PlayerManager.Instance.CurrentLives = PlayerManager.Instance.startingLives;
        SceneManager.LoadScene("SampleScene 1");
        Debug.Log(PlayerManager.Instance.CurrentLives);
    }
    public void Quit()
    {
        SceneManager.LoadScene("MenuStartGame");
    }
}
