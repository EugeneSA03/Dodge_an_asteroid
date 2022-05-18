using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrate : MonoBehaviour
{
    public void OnCalibrateButtonClick() {
        PlayerPrefs.SetFloat("CalibrateX", Input.acceleration.x);
        PlayerPrefs.SetFloat("CalibrateY", Input.acceleration.y);
    }
}
