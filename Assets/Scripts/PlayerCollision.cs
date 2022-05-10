using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(gStat => gameStatus = gStat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (gameStatus != 3) {
            GlobalEventManager.OnGameStatusChanged.Invoke(3);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Coin" && this.GetComponent<Collider>().tag == "MainCollider") {
            Coins.AddCoin();
            SpawnerScript.CoinDestroy(other);
        }
    }
}
