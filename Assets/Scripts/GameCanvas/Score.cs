using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpUI;
    [SerializeField] private float scoreMultiply = 1;
    [SerializeField] private float scoreForLvl = 1000;
    [SerializeField] private float scoreForCoin = 100;

    [SerializeField] public float scoreValue = 0;

    private int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        tmpUI = this.GetComponent<TextMeshProUGUI>();
        
        GlobalEventManager.OnGameStatusChanged.AddListener(GameStatus => gameStatus = GameStatus);
    }

    private void FixedUpdate() {
        if (gameStatus == 1) {
            scoreValue += Time.unscaledDeltaTime * scoreMultiply * (SpawnerScript.asteroids.Count / 10);
            tmpUI.SetText(Mathf.Round(scoreValue).ToString());
        }
    }
}
