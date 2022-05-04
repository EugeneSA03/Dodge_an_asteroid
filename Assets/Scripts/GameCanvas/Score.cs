using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpUI;
    [SerializeField] static private float scoreMultiplier = 1;
    [SerializeField] static private float scoreForLvl = 1000;
    [SerializeField] static private float scoreForCoin = 100;

    [SerializeField] static private float scoreValue = 0;

    private int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        tmpUI = this.GetComponent<TextMeshProUGUI>();
        
        GlobalEventManager.OnGameStatusChanged.AddListener(GameStatus => gameStatus = GameStatus);
    }

    private void FixedUpdate() {
        if (gameStatus == 1) {
            scoreValue += Time.unscaledDeltaTime * scoreMultiplier * (SpawnerScript.asteroids.Count / 10);
            tmpUI.SetText(Mathf.Round(scoreValue).ToString());
        }
    }

    public static void AddScoreForCoin() {
        scoreValue += scoreForCoin * scoreMultiplier;
    }

    public static void AddScoreForLvl() {
        scoreValue += scoreForLvl * scoreMultiplier;
    }

    public static void IncreaseScoreMultiplier() {
        scoreMultiplier += 0.15f;
    }
}
