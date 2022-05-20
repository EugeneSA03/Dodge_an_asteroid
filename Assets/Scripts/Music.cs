using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    void Start() {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.loop = true;
        SetVolume();

        GlobalEventManager.OnSettingsChanged.AddListener(SetVolume);
    }

    void SetVolume() {
        audioSource.volume = PlayerPrefs.GetInt("Music") / 100f;
    }
}
