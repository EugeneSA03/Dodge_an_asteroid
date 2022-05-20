using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private Light eLight;

    private ParticleSystem.SizeOverLifetimeModule sizeOverLtPs;

    void Start() {
        SetEngine(0);

        sizeOverLtPs = ps.sizeOverLifetime;

        GlobalEventManager.OnGameStatusChanged.AddListener(SetEngine);
    }

    void SetEngine(int gameStatus) {
        switch (gameStatus) {
            default:
                ps.Stop();
                eLight.intensity = 0;
                break;
            case 1:
                sizeOverLtPs.enabled = false;
                ps.Play();
                eLight.intensity = 5;
                break;
            case 2:
                sizeOverLtPs.enabled = true;
                ps.Play();
                eLight.intensity = 10;
                break;
        }
    }
}
