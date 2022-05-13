using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputType : MonoBehaviour
{
    private TextMeshProUGUI btnText;

    private void Start() {
        btnText = this.GetComponent<Button>().transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnInputTypeButtonClick() {
        btnText.SetText(btnText.text == "Accelerometer" ? "Joystick" : "Accelerometer");
    }
}
