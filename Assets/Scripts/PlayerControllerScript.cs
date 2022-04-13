using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float playerSpeed = 0.1f;

    private GameObject scrpt;
    private GameObject player = null;

    public static Vector3 direction = Vector3.zero;
    private int _gameStatus;


    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(gameStatus => _gameStatus = gameStatus);
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (_gameStatus == 1) {
            direction = Vector3.zero;

            direction.x = -Input.acceleration.x * playerSpeed;
            direction.y = Input.acceleration.y * playerSpeed;

            if (Input.GetKey(KeyCode.RightArrow))
                direction.x = -1 * playerSpeed;
            if (Input.GetKey(KeyCode.UpArrow))
                direction.y = 1 * playerSpeed;
            if (Input.GetKey(KeyCode.LeftArrow))
                direction.x = 1 * playerSpeed;
            if (Input.GetKey(KeyCode.DownArrow))
                direction.y = -1 * playerSpeed;

            for (int i = 0; i < SpawnerScript.enemies.Count; i++) {
                //direction.z = SpawnerScript.enemies[i].speed + direction.z / 2;
                SpawnerScript.enemies[i].body.transform.Translate(direction, Space.World);
            }
            //player.GetComponentInChildren<Transform>().Translate(direction);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        GlobalEventManager.OnGameStatusChanged.Invoke(0);
    }
}
