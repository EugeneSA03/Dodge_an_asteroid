using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject menuUI = null;
    [SerializeField] private GameObject overUI = null;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 120;

        GlobalEventManager.OnGameStatusChanged.AddListener(SetUI);
        GlobalEventManager.OnGameStatusChanged.Invoke(4);
    }

    void SetUI(int gameStatus) {
        switch (gameStatus) {
            case 0: 
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                break;
            case 1:
                menuUI.SetActive(false);
                gameUI.SetActive(true);
                overUI.SetActive(false);
                break;
            case 2:
                menuUI.SetActive(false);
                gameUI.SetActive(true);
                overUI.SetActive(false);
                break;
            case 3:
                menuUI.SetActive(false);
                gameUI.SetActive(false);
                overUI.SetActive(true);
                break;
            case 4:
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                break;
        }
    }
}
