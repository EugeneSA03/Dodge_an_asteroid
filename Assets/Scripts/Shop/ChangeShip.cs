using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShip : MonoBehaviour
{
    private int index;

    public void OnLeftButtonClick() {
        index = PlayerPrefs.GetInt("ShipIndex");
        if (index == 0) {
            PlayerPrefs.SetInt("ShipIndex", 3);
        }
        else {
            PlayerPrefs.SetInt("ShipIndex", index - 1);
        }
        GlobalEventManager.OnSettingsChanged.Invoke();
    }

    public void OnRightButtonClick() {
        index = PlayerPrefs.GetInt("ShipIndex");
        if (index == 3) {
            PlayerPrefs.SetInt("ShipIndex", 0);
        }
        else {
            PlayerPrefs.SetInt("ShipIndex", index + 1);
        }
        GlobalEventManager.OnSettingsChanged.Invoke();
    }
}
