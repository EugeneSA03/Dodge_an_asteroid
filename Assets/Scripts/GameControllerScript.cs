using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject gameUI = null;
    [SerializeField] private GameObject menuUI = null;
    [SerializeField] private GameObject overUI = null;
    [SerializeField] private GameObject settUI = null;
    [SerializeField] private GameObject shopUI = null;
    [SerializeField] private GameObject fpsUI = null;
    [SerializeField] private GameObject joystickUI = null;
    [SerializeField] private GameObject guideUI = null;

    [SerializeField] private List<GameObject> ships;

    private TextMeshProUGUI fpsTxt;
    private GameObject[] players;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        UpdateSettings();

        fpsTxt = fpsUI.GetComponentInChildren<TextMeshProUGUI>();
        InvokeRepeating("UpdateFPS", 0.5f, 1f);

        GlobalEventManager.OnGameStatusChanged.AddListener(SetUI);
        if (PlayerPrefs.GetInt("First start") == 0) {
            guideUI.SetActive(true);
            GlobalEventManager.OnGameStatusChanged.Invoke(7);
            PlayerPrefs.SetInt("First start", 1);
        }
        else {
            guideUI.SetActive(false);
            GlobalEventManager.OnGameStatusChanged.Invoke(4);
        }

        GlobalEventManager.OnSettingsChanged.AddListener(UpdateSettings);
    }

    private void FixedUpdate() {
        //Debug.Log(gameUI.activeSelf);
    }

    void SetUI(int gameStatus) {
        switch (gameStatus) {
            case 0: 
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
            case 1:
                menuUI.SetActive(false);
                gameUI.SetActive(true);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
            case 2:
                menuUI.SetActive(false);
                gameUI.SetActive(true);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
            case 3:
                menuUI.SetActive(false);
                gameUI.SetActive(false);
                overUI.SetActive(true);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
            case 4:
                menuUI.SetActive(true);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
            case 5:
                menuUI.SetActive(false);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                settUI.SetActive(true);
                shopUI.SetActive(false);
                break;
            case 6:
                menuUI.SetActive(false);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(true);
                break;
            case 7:
                menuUI.SetActive(false);
                gameUI.SetActive(false);
                overUI.SetActive(false);
                settUI.SetActive(false);
                shopUI.SetActive(false);
                break;
        }
    }

    void UpdateSettings() {
        Application.targetFrameRate = PlayerPrefs.GetInt("FrameRate") + 3;

        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++) {
            Destroy(players[i]);
        }

        Instantiate(ships[PlayerPrefs.GetInt("ShipIndex")]);

        joystickUI.SetActive(PlayerPrefs.GetInt("InputType") == 1);

        ChangeFPSUI();
    }

    void ChangeFPSUI() {
        if (PlayerPrefs.GetInt("ShowFPS") == 0)
            fpsUI.SetActive(false);
        else
            fpsUI.SetActive(true);
    }

    void UpdateFPS() {
        fpsTxt.SetText(((int)(1f / Time.unscaledDeltaTime)).ToString());
    }
}
