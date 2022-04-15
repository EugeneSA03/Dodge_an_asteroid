using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineParticles : MonoBehaviour {
    
    /// <summary>
    /// 0 - main left
    /// 1 - main right
    /// 2 - front left
    /// 3 - front right
    /// 4 - top left
    /// 5 - top right
    /// 6 - bottom left
    /// 7 - bottom right
    /// </summary>
    public List<ParticleSystem> engines;
    public float forceSize = 10.0f;
    public Vector3 particleSpeed = new Vector3(1.0f, 1.0f, 5.0f);

    private List<ParticleSystem.ForceOverLifetimeModule> folts;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(SetParticleStatus);

        for (int i = 0; i < engines.Count; i++) {
            //folts.Add(engines[i].forceOverLifetime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        Vector3 dir = PlayerControllerScript.direction;
        //Main left
        {
            ParticleSystem.ForceOverLifetimeModule fo = engines[0].forceOverLifetime;
            fo.x = new ParticleSystem.MinMaxCurve((dir.x * -forceSize) + particleSpeed.x);
            fo.y = new ParticleSystem.MinMaxCurve((dir.y * forceSize) + particleSpeed.y);
            fo.z = new ParticleSystem.MinMaxCurve((dir.z * forceSize) + particleSpeed.z);
        }
        //Main right
        {
            ParticleSystem.ForceOverLifetimeModule fo = engines[1].forceOverLifetime;
            fo.x = new ParticleSystem.MinMaxCurve((dir.x * -forceSize) + particleSpeed.x);
            fo.y = new ParticleSystem.MinMaxCurve((dir.y * forceSize) + particleSpeed.y);
            fo.z = new ParticleSystem.MinMaxCurve((dir.z * forceSize) + particleSpeed.z);
        }
    }

    private void SetParticleStatus(int gameStatus) {
        if (gameStatus == 0) {
            for (int i = 0; i < engines.Count; i++) {
                engines[i].Stop();
            }
        }
        else if (gameStatus == 1) {
            for (int i = 0; i < engines.Count; i++) {
                engines[i].Play();
            }
        }
        else {
            for (int i = 0; i < engines.Count; i++) {
                engines[i].Pause();
            }
        }
    }
}
