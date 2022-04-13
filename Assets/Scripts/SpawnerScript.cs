using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerScript : MonoBehaviour
{
    public class Enemy {
        public GameObject body;
        public float speed;
        public Vector3 rotation;
    }

    public GameObject[] enemyMeshs = null;

    public int enemyScaleMax = 200;

    public int enemySpeedMin = 20;
    public int enemySpeedMax = 90;

    public uint numOfEnemies = 300;

    public Vector2 spawnField = Vector2.zero;

    public bool isPlaying = false;
    public static List<Enemy> enemies;
    private GameObject spawner = null;
    private System.Random random = null;
    private float coneSpawn = -1.2f;


    private int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(GameStatus => gameStatus = GameStatus);
        enemies = new List<Enemy>();
        spawner = this.gameObject;
        random = new System.Random();
    }

    void FixedUpdate() {
        if (gameStatus == 1) {
            if (enemies.Count < numOfEnemies) {
                SpawnEnemy(2);
            }
        }
        if (gameStatus == 1) {
            for (int i = 0; i < enemies.Count; i++) {
                if (enemies[i].body.transform.position.z > spawner.transform.position.z + 1 ||
                    enemies[i].body.transform.position.z < -10 ||
                    Mathf.Abs(enemies[i].body.transform.position.x) > spawnField.x ||
                    Mathf.Abs(enemies[i].body.transform.position.y) > spawnField.y) {
                    DestroyImmediate(enemies[i].body, true);
                    enemies.RemoveAt(i);
                }
                else {
                    enemies[i].body.transform.Rotate(enemies[i].rotation);
                    enemies[i].body.transform.Translate(0, 0, -enemies[i].speed * 0.1f, Space.World);
                }
            }
        }
    }

    private void SpawnEnemy(int count) {
        for (int i = 0; i < count; i++) {
            Enemy et = new Enemy();
            et.body = Instantiate(enemyMeshs[random.Next(0, 4)]);
            et.speed = random.Next(enemySpeedMin, enemySpeedMax) / 10;
            et.rotation = new Vector3(random.Next(1, 40) / 15.0f, random.Next(1, 40) / 15.0f, random.Next(1, 40) / 15.0f);

            float etscale = enemyScaleMax - enemyScaleMax * 8 * et.speed / enemySpeedMax;
            et.body.transform.localScale = new Vector3(etscale, etscale, etscale);
            et.body.GetComponent<Rigidbody>().mass = etscale;

            Vector3 loc = new Vector3(random.Next(-(int)spawnField.x, (int)spawnField.x), random.Next(-(int)spawnField.y, (int)spawnField.y), spawner.transform.position.z);
            loc.z += Mathf.Sqrt((loc.x * loc.x) + (loc.y * loc.y)) * coneSpawn;

            et.body.transform.position = loc;
            et.body.transform.rotation = new Quaternion((float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, 1);

            enemies.Add(et);
        }
    }
}
