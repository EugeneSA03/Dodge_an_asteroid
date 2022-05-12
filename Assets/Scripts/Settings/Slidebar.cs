using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slidebar : MonoBehaviour
{
    [SerializeField] private TMP_InputField valueField;
    [SerializeField] private Slider slider;

    [SerializeField] private int minValue;
    [SerializeField] private int maxValue;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponentInChildren<Slider>();
        slider.value = int.Parse(valueField.text);
        valueField.text = slider.value.ToString();
    }

    public void OnSliderValueChanged() {
        slider.value = Mathf.RoundToInt(slider.value);
        valueField.text = slider.value.ToString();
    }

    public void OnFieldValueChanged() {
        if (int.Parse(valueField.text) > maxValue) 
            valueField.text = maxValue.ToString();
        else if (int.Parse(valueField.text) < minValue)
            valueField.text = minValue.ToString();
        slider.value = int.Parse(valueField.text);
    }
}
