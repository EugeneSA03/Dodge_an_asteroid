using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RestartGame() {
        Score.ResetScore();
        Coins.ResetCoins();
        SpawnerScript.ResetAsteroids();
        StarSpawner.ResetStar();
        GlobalEventManager.OnGameStatusChanged.Invoke(0);
    }
}
