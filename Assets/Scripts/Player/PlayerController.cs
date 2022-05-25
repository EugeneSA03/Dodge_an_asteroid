using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camMain;
    [SerializeField] private Vector3 camOffset;
    [SerializeField] private Vector3 camDefaultPosition;

    [SerializeField] private int gameStatus;

    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float playerSpeed = 1;
    [SerializeField] private float accelerometerMultiply = 2f;

    [SerializeField] private static float starSpeed = 10;

    Vector3 direction = Vector3.zero;
    public static Vector3 offset = Vector3.zero;

    bool isJoystick;

    // Start is called before the first frame update
    void Start()
    {
        SetInputType();

        GlobalEventManager.OnGameStatusChanged.AddListener(gStat => gameStatus = gStat);
        camMain = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        SetJoystick();

        GlobalEventManager.OnSettingsChanged.AddListener(SetInputType);
        GlobalEventManager.OnSettingsChanged.AddListener(SetAccelerometerOffset);
        GlobalEventManager.OnSettingsChanged.AddListener(SetJoystick);
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

        if (isJoystick) {
            direction.x = -joystick.Horizontal * playerSpeed;
            direction.y = -joystick.Vertical * playerSpeed;
        }
        else {
            direction = Input.acceleration;

            direction.x = Mathf.Clamp(direction.x * accelerometerMultiply, -1, 1);
            direction.y = Mathf.Clamp(direction.y * accelerometerMultiply, -1, 1);

            direction.x = (direction.x - offset.x) * -playerSpeed;
            direction.y = (direction.y - offset.y) * playerSpeed;

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

    void SetInputType() {
        isJoystick = PlayerPrefs.GetInt("InputType") == 1;
    }

    void SetJoystick() {
        if (isJoystick)
            joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();
    }

    public static void SetAccelerometerOffset() {
        offset.x = PlayerPrefs.GetFloat("CalibrateX");
        offset.y = PlayerPrefs.GetFloat("CalibrateY");
    }
}
