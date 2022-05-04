using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerScript : MonoBehaviour
{
    public class Asteroid {
        public GameObject body;
        /// <summary>
        /// 0 - asteroid;
        /// 1 - gold
        /// </summary>
        public int type;
        public float speed;
        public Vector3 rotation;
    }

    [SerializeField] private GameObject[] asteroidMeshs = null;

    [SerializeField] private int asteroidScaleMax = 200;
    [SerializeField] private int asteroidSpeedMin = 20;
    [SerializeField] private int asteroidSpeedMax = 90;
    [SerializeField] private uint numOfAsteroids = 300;

    [SerializeField] private Vector2 spawnField = Vector2.zero;

    [SerializeField] private float coneSpawn = -1.2f;

    [SerializeField] private int goldChance;

    public static List<Asteroid> asteroids;

    private GameObject spawner = null;
    private System.Random random = null;

    private int gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnGameStatusChanged.AddListener(GameStatus => gameStatus = GameStatus);
        asteroids = new List<Asteroid>();
        spawner = this.gameObject;
        random = new System.Random();
    }

    void FixedUpdate() {
        if (gameStatus == 1) {
            if (asteroids.Count < numOfAsteroids) {
                SpawnAsteroid(2);
            }
        }
        if (gameStatus == 1 || gameStatus == 3) {
            for (int i = 0; i < asteroids.Count; i++) {
                if (asteroids[i].body.transform.position.z > spawner.transform.position.z + 1 ||
                    asteroids[i].body.transform.position.z < -10 ||
                    Mathf.Abs(asteroids[i].body.transform.position.x) > spawnField.x ||
                    Mathf.Abs(asteroids[i].body.transform.position.y) > spawnField.y) {
                    DestroyImmediate(asteroids[i].body, true);
                    asteroids.RemoveAt(i);
                }
                else {
                    asteroids[i].body.transform.Rotate(asteroids[i].rotation);
                    asteroids[i].body.transform.Translate(0, 0, -asteroids[i].speed * 0.1f, Space.World);
                }
            }
        }
    }

    private void SpawnAsteroid(int count) {
        for (int i = 0; i < count; i++) {
            Asteroid ast = new Asteroid();

            int chance = random.Next(0, 100);
            if (chance >= 0 && chance < goldChance) {
                ast.body = Instantiate(asteroidMeshs[0]);
            }
            else {
                ast.body = Instantiate(asteroidMeshs[random.Next(1, 6)]);
            }

            ast.speed = random.Next(asteroidSpeedMin, asteroidSpeedMax) / 10;
            ast.rotation = new Vector3(random.Next(1, 40) / 15.0f, random.Next(1, 40) / 15.0f, random.Next(1, 40) / 15.0f);

            float etscale = asteroidScaleMax - asteroidScaleMax * 8 * ast.speed / asteroidSpeedMax;
            ast.body.transform.localScale = new Vector3(etscale, etscale, etscale);
            ast.body.GetComponent<Rigidbody>().mass = etscale;

            Vector3 loc = new Vector3(random.Next(-(int)spawnField.x, (int)spawnField.x), random.Next(-(int)spawnField.y, (int)spawnField.y), spawner.transform.position.z);
            loc.z += Mathf.Sqrt((loc.x * loc.x) + (loc.y * loc.y)) * coneSpawn;

            ast.body.transform.position = loc;
            ast.body.transform.rotation = new Quaternion((float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, 1);

            asteroids.Add(ast);
        }
    }

    public static void CoinDestroy(Collider coinCollider) {
        for (int i = 0; i < asteroids.Count; i++) {
            if (asteroids[i].body.tag == "Coin") {
                if (asteroids[i].body.GetComponent<Collider>() == coinCollider) {
                    Destroy(asteroids[i].body);
                    asteroids.RemoveAt(i);
                }
            }
        }
    }
}
