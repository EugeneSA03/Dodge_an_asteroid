using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePart : MonoBehaviour
{
    private ParticleSystem ps;
    private Vector3 dir;
    private ParticleSystem.ForceOverLifetimeModule forceOverLT;

    // Start is called before the first frame update
    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
        forceOverLT = ps.forceOverLifetime;
        GlobalEventManager.OnGameStatusChanged.AddListener(SetPlayMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        dir = PlayerControllerScript.direction;
        forceOverLT.x = new ParticleSystem.MinMaxCurve(dir.x * 20);
        forceOverLT.y = new ParticleSystem.MinMaxCurve(dir.y * 20);
        forceOverLT.z = new ParticleSystem.MinMaxCurve(dir.z * 20);
    }

    private void SetPlayMode(int GameStatus) {
        if (GameStatus == 0) {
            ps.Stop();
        }
        else if (GameStatus == 1) {
            ps.Play();
        }
        else {
            ps.Pause();
        }
    }
}
