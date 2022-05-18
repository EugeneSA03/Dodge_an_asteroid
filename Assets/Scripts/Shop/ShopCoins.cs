using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsTxt;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener((gameStat) => UpdateCoins());
    }

    void UpdateCoins() {
        coinsTxt.SetText(PlayerPrefs.GetInt("Total coins").ToString());
    }
}
