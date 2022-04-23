using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    private float scoreValue = 0;
    private Time time;
    private int gameStatus;
    private bool inGame = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.fontSize = Screen.height / 20;
        inGame = true;
        GlobalEventManager.OnGameStatusChanged.AddListener(GameStatus => { gameStatus = GameStatus; inGame = gameStatus == 1;});
    }

    private void FixedUpdate() {
        if (inGame) {
            scoreValue += Time.unscaledDeltaTime;
            scoreText.text = "Score: " + (Mathf.Round(scoreValue * 100) / 100).ToString();
        }
    }
}
