using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    private bool isGameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {

    }
}
