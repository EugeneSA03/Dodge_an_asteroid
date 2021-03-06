using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void StartButtonPressed() {
        GlobalEventManager.OnGameStatusChanged.Invoke(1);
    }

    public void OnExitButtonClick() {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void OnSettingsButtonClick() {
        GlobalEventManager.OnGameStatusChanged.Invoke(5);
    }

    public void OnShopButtonClick() {
        GlobalEventManager.OnGameStatusChanged.Invoke(6);
    }

    public void OnSelectButtonClick() {
        if (ShipImage.IsShipBought(ShipImage.currentIndex))
            PlayerPrefs.SetInt("ShipIndex", ShipImage.currentIndex);
        else
            PlayerPrefs.SetInt("ShipIndex", 0);
        GlobalEventManager.OnSettingsChanged.Invoke();
        GlobalEventManager.OnGameStatusChanged.Invoke(0);
    }
}
