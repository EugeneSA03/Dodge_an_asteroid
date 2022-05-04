using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    [SerializeField] private static TextMeshProUGUI tmpUI;
    [SerializeField] private static int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        tmpUI = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tmpUI.SetText(coins.ToString());
    }

    public static void AddCoin() {
        coins++;
        Score.AddScoreForCoin();
    }
}
