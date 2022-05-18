using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    [SerializeField] private TMP_InputField music;
    [SerializeField] private TMP_InputField frameRate;
    [SerializeField] private Toggle showFPS;
    [SerializeField] private TextMeshProUGUI inputType;
    [SerializeField] private float calibrateX;
    [SerializeField] private float calibrateY;

    public void OnSaveButtonClick() {
        PlayerPrefs.SetInt("Music", int.Parse(music.text));
        PlayerPrefs.SetInt("FrameRate", int.Parse(frameRate.text));
        PlayerPrefs.SetInt("ShowFPS", showFPS.isOn ? 1 : 0);
        PlayerPrefs.SetInt("InputType", inputType.text == "Accelerometer" ? 0 : 1);
        PlayerPrefs.SetFloat("calibrateX", calibrateX);
        PlayerPrefs.SetFloat("calibrateY", calibrateY);
        PlayerPrefs.Save();

        GlobalEventManager.OnSettingsChanged.Invoke();
        GlobalEventManager.OnGameStatusChanged.Invoke(0);
    }
}
