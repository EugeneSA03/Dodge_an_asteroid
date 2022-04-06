using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour
{
    public void StartButtonPressed() {
        GlobalEventManager.OnGameStatusChanged.Invoke(1);
    }
}
