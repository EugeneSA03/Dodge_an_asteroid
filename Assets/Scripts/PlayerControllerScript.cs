using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] private Camera camMain;
    [SerializeField] private float camSpeed;
    [SerializeField] private Vector3 camOffset;
    [SerializeField] private Vector3 camDefaultPosition;

    [SerializeField] private int gameStatus;
    [SerializeField] private float playerSpeed = 0.1f;

    [SerializeField] private float starSpeed = 0.1f;

    public static Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(_gameStatus => gameStatus = _gameStatus);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        
        if (gameStatus == 1) {
            direction = Vector3.zero;

            direction.x = -Input.acceleration.x * playerSpeed;
            direction.y = Input.acceleration.y * playerSpeed;

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

            for (int i = 0; i < SpawnerScript.asteroids.Count; i++) {
                SpawnerScript.asteroids[i].body.transform.Translate(direction, Space.World);
            }

            for (int i = 0; i < StarSpawner.stars.Count; i++) {
                Vector3 temp = new Vector3( StarSpawner.stars[i].prefab.transform.position.x,
                                            StarSpawner.stars[i].prefab.transform.position.y,
                                            StarSpawner.stars[i].prefab.transform.position.z - starSpeed * Time.deltaTime);
                StarSpawner.stars[i].prefab.transform.position = temp;
            }

            camMain.transform.position = new Vector3(camDefaultPosition.x + (-direction.x * camOffset.x),
                                                    camDefaultPosition.y + (-direction.y * camOffset.y),
                                                    camDefaultPosition.z + (-direction.z * camOffset.z));
        }
    }
}
