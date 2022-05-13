using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ApplicationEnter : MonoBehaviour {
    [SerializeField] private TMP_InputField music;
    [SerializeField] private TMP_InputField frameRate;
    [SerializeField] private Toggle showFPS;
    [SerializeField] private TextMeshProUGUI inputType;
    [SerializeField] private float calibrateX;
    [SerializeField] private float calibrateY;

    void Awake() {
        if (!PlayerPrefs.HasKey("Total coins")) {
            PlayerPrefs.SetInt("Total coins", 0);
        }
        if (!PlayerPrefs.HasKey("High score")) {
            PlayerPrefs.SetFloat("High score", 0);
        }
        if (!PlayerPrefs.HasKey("First start")) {
            PlayerPrefs.SetInt("First start", 0);
        }

        LoadSettings();
    }

    void LoadSettings() {
        if (!PlayerPrefs.HasKey("Music")) {
            PlayerPrefs.SetInt("Music", 70);
        }
        if (!PlayerPrefs.HasKey("FrameRate")) {
            PlayerPrefs.SetInt("FrameRate", 30);
        }
        if (!PlayerPrefs.HasKey("ShowFPS")) {
            PlayerPrefs.SetInt("ShowFPS", 0);
        }
        if (!PlayerPrefs.HasKey("InputType")) {
            PlayerPrefs.SetInt("InputType", 0);
        }
        if (!PlayerPrefs.HasKey("CalibrateX")) {
            PlayerPrefs.SetFloat("CalibrateX", 0);
        }
        if (!PlayerPrefs.HasKey("CalibrateY")) {
            PlayerPrefs.SetFloat("CalibrateY", 0);
        }
        PlayerPrefs.Save();

        music.text = PlayerPrefs.GetInt("Music").ToString();
        frameRate.text = PlayerPrefs.GetInt("FrameRate").ToString();
        showFPS.isOn = PlayerPrefs.GetInt("ShowFPS") == 1 ? true : false;
        inputType.SetText(PlayerPrefs.GetInt("InputType") == 0 ? "Accelerometer" : "Joystick");

        GlobalEventManager.OnSettingsChanged.Invoke();
    }
}
