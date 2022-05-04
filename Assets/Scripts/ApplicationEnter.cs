using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationEnter : MonoBehaviour
{
    void Start() {
        if (!PlayerPrefs.HasKey("Total coins")) {
            PlayerPrefs.SetInt("Total coins", 0);
        }
        if (!PlayerPrefs.HasKey("High score")) {
            PlayerPrefs.SetFloat("High score", 0);
        }
        if (!PlayerPrefs.HasKey("First start")) {
            PlayerPrefs.SetInt("First start", 0);
        }
    }
}
