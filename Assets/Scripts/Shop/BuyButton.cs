using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cost;

    private int total;

    public void OnBuyButtonClick() {
        total = PlayerPrefs.GetInt("Total coins");
        int shipCost = int.Parse(cost.text);

        if (shipCost <= total) {
            PlayerPrefs.SetInt("Total coins", total - shipCost);
            PlayerPrefs.SetString("SH" + (ShipImage.currentIndex + 1).ToString(), "true");
            PlayerPrefs.Save();
            GlobalEventManager.OnSettingsChanged.Invoke();
        }
    }
}
