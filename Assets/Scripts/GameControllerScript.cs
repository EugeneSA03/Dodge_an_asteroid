using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject gameUI = null;
    public GameObject menuUI = null;


    /// <summary>
    /// <list type="bullet">
    /// <item>(0) ended</item>
    /// <item>(1) started</item>
    /// <item>(2) paused</item>
    /// </list>
    /// </summary>
    private int _gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        GlobalEventManager.OnGameStatusChanged.AddListener(SetUI);
        GlobalEventManager.OnGameStatusChanged.Invoke(0);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        
    }

    void SetUI(int _gameStatus) {
        if (_gameStatus == 0) {
            gameUI.SetActive(false);
            menuUI.SetActive(true);
        }
        else if (_gameStatus == 1) {
            gameUI.SetActive(true);
            menuUI.SetActive(false);
        }
    }
}
