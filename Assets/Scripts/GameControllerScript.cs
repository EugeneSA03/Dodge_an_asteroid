using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public class Player {
        public GameObject player;
    }

    public GameObject playerPrefab = null;

    private bool isGameStarted = false;
    private Player player = null;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        player = new Player();
    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && !isGameStarted) {
            isGameStarted = !isGameStarted;
            player.player = Instantiate(playerPrefab);
        }
        if (Input.GetButtonDown("Fire1") && !isGameStarted) {
            isGameStarted = !isGameStarted;
            player.player = Instantiate(playerPrefab);
        }
    }

    void FixedUpdate() {
    }
}
