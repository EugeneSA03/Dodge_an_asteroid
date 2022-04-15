using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float playerSpeed = 0.1f;

    public Vector3 maxRotationAngle;

    private GameObject scrpt;
    private GameObject player = null;
    private List<BoxCollider> colliders = new List<BoxCollider>();

    public static Vector3 direction = Vector3.zero;
    private int _gameStatus;


    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(gameStatus => _gameStatus = gameStatus);
        player = this.gameObject;
        colliders.Add(player.GetComponents<BoxCollider>()[0]);
        colliders.Add(player.GetComponents<BoxCollider>()[1]);
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

            Debug.Log(colliders[0].size + " " + colliders[1].size);
            
            for (int i = 0; i < player.transform.childCount; i++) {
                
            }

            if (Input.GetKey(KeyCode.RightArrow)) {
                direction.x = -1 * playerSpeed;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                direction.y = 1 * playerSpeed;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                direction.x = 1 * playerSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                direction.y = -1 * playerSpeed;
            }

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
