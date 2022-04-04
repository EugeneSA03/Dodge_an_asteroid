using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject gameUI = null;
    public GameObject menuUI = null;

    private bool isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameUI.SetActive(false);
        menuUI.SetActive(true);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        isGameStarted = false;

        
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {

    }
}
