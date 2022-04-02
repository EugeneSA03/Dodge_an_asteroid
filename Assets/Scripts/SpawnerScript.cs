using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    class Enemy {
        public GameObject body;
        public float speed;
        public Vector3 rotation;
    }

    public GameObject[] enemyMeshs = null;

    public int enemyScaleMax = 200;

    public int enemySpeedMin = 20;
    public int enemySpeedMax = 90;

    public uint numOfEnemies = 300;

    private List<Enemy> enemies;
    private GameObject spawner = null;
    private System.Random random = null;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        spawner = this.gameObject;
        random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count < numOfEnemies) {
            Enemy et = new Enemy();
            et.body = Instantiate(enemyMeshs[random.Next(0, 4)]);
            et.speed = random.Next(enemySpeedMin, enemySpeedMax) / 10;
            et.rotation = new Vector3(random.Next(1, 40) / 10.0f, random.Next(1, 40) / 10.0f, random.Next(1, 40) / 10.0f);

            float etscale = enemyScaleMax - enemyScaleMax * 10 * et.speed / enemySpeedMax;
            et.body.transform.localScale = new Vector3(etscale, etscale, etscale);
            et.body.GetComponent<Rigidbody>().mass = etscale;

            et.body.transform.position = new Vector3(random.Next(-10, 10), random.Next(-15, 15), spawner.transform.position.z);
            et.body.transform.rotation = new Quaternion((float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, (float)random.NextDouble() * 1000 % 360, 1);

            enemies.Add(et);
        }
    }

    void FixedUpdate() {
        for (int i = 0; i < enemies.Count; i++) {
            if (enemies[i].body.transform.position.z < -20 ||
                Mathf.Abs(enemies[i].body.transform.position.x) > 70 ||
                Mathf.Abs(enemies[i].body.transform.position.y) > 35) {
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
