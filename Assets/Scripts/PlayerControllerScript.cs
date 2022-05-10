using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] private Camera camMain;
    [SerializeField] private Vector3 camOffset;
    [SerializeField] private Vector3 camDefaultPosition;

    [SerializeField] private int gameStatus;
    [SerializeField] private float playerSpeed = 1;

    [SerializeField] private static float starSpeed = 10;

    public static Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(gStat => gameStatus = gStat);
        camMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate() {
        if (gameStatus == 1 || gameStatus == 2) {
            direction = Vector3.zero;
            MoveAsteroids(); 
            MoveCamera();
            MoveStar(false);
        }
    }

    private void MoveAsteroids() {
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
    }

    private void MoveCamera() {
        camMain.transform.position = new Vector3(camDefaultPosition.x + (-direction.x * camOffset.x),
                                                 camDefaultPosition.y + (-direction.y * camOffset.y),
                                                 camDefaultPosition.z + (-direction.z * camOffset.z));
    }

    public static void MoveStar(bool isJump) {
        if (isJump) {
            StarSpawner.star.prefab.transform.position = new Vector3(StarSpawner.star.prefab.transform.position.x,
                                                                     StarSpawner.star.prefab.transform.position.y,
                                                                     StarSpawner.star.prefab.transform.position.z - starSpeed * 10 * Time.deltaTime);
        }
        else if (StarSpawner.star != null) {
            StarSpawner.star.prefab.transform.position = new Vector3(StarSpawner.star.prefab.transform.position.x,
                                                                     StarSpawner.star.prefab.transform.position.y,
                                                                     StarSpawner.star.prefab.transform.position.z - starSpeed * Time.deltaTime);
        }
    }
}
