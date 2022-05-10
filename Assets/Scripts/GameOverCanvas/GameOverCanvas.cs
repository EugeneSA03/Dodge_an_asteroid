using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI coinTxt;

    // Start is called before the first frame update
    void Awake()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(GameOver);   
    }

    void GameOver(int _gameStatus) {
        if (_gameStatus == 3) {
            int totalCoins = PlayerPrefs.GetInt("Total coins");
            totalCoins += Coins.GetCoins();
            PlayerPrefs.SetInt("Total coins", totalCoins);

            float highScore = PlayerPrefs.GetFloat("High score");
            if (Score.GetScore() > highScore) {
                PlayerPrefs.SetFloat("High score", Mathf.Round(Score.GetScore() * 100) / 100);
            }

            scoreTxt.SetText(PlayerPrefs.GetFloat("High score").ToString());
            coinTxt.SetText(PlayerPrefs.GetInt("Total coins").ToString());
            PlayerPrefs.Save();
        }
    }
}

