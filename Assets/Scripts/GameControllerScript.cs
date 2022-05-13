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

    private TextMeshProUGUI fpsTxt;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        UpdateSettings();

        fpsTxt = fpsUI.GetComponentInChildren<TextMeshProUGUI>();
        InvokeRepeating("UpdateFPS", 1, 0.5f);

        GlobalEventManager.OnGameStatusChanged.AddListener(SetUI);
        GlobalEventManager.OnGameStatusChanged.Invoke(4);

        GlobalEventManager.OnSettingsChanged.AddListener(UpdateSettings);
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
        }
    }

    void UpdateSettings() {
        Application.targetFrameRate = PlayerPrefs.GetInt("FrameRate") + 3;

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
