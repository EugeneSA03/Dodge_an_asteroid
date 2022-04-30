using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject gameUI = null;
    public GameObject menuUI = null;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;

        GlobalEventManager.OnGameStatusChanged.AddListener(SetUI);
        GlobalEventManager.OnGameStatusChanged.Invoke(4);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        
    }

    void SetUI(int gameStatus) {
        switch (gameStatus) {
            case 0: 
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                break;
            case 1:
                menuUI.SetActive(false);
                gameUI.SetActive(true);
                break;
            case 4:
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                break;
        }
    }
}
