using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private class Enemy {
        public GameObject prefab = null;
        public float speed = 0;
        
    }

    public GameObject[] prefabs;
    public int maxEnemies = 200;
    public float minEnemyScale = 20;
    public float maxEnemyScale = 250;
    public uint minEnemySpeed = 1;
    public uint maxEnemySpeed = 3;

    private GameObject spawner = null;
    private List<Enemy> enemies = null;
    private Enemy enemyTemp = null;
    private System.Random random = null;

    // Start is called before the first frame update
    void Start()
    {
        spawner = this.gameObject;
        enemies = new List<Enemy> ();
        random = new System.Random ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (enemies.Count < maxEnemies) {
            enemyTemp = new Enemy ();
            enemyTemp.prefab = Instantiate(prefabs[random.Next(0, 4)]);

            enemyTemp.speed = (float)random.NextDouble() * (maxEnemySpeed - minEnemySpeed) + minEnemySpeed;

            float eScale = (enemyTemp.speed / maxEnemySpeed) * (maxEnemyScale - minEnemyScale) + minEnemyScale;

            enemyTemp.prefab.GetComponent<Rigidbody>().mass = eScale;
            enemyTemp.prefab.transform.localScale = new Vector3(eScale, eScale, eScale);

            enemyTemp.prefab.transform.position = new Vector3(random.Next(-70, 70), random.Next(-35, 35), spawner.transform.position.z);
            enemyTemp.prefab.transform.rotation = new Quaternion(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360), 1);
            enemyTemp.prefab.transform.Rotate(new Vector3(random.Next(0, 10), random.Next(0, 10), random.Next(0, 10)));

            enemies.Add(enemyTemp);
        }
        for (int i = 0; i < enemies.Count; i++) {
            if (enemies[i].prefab.transform.position.z < -20 ||
                Mathf.Abs(enemies[i].prefab.transform.position.x) > 70 ||
                Mathf.Abs(enemies[i].prefab.transform.position.y) > 35) {
                DestroyImmediate (enemies[i].prefab, true);
                enemies.RemoveAt (i);
            }
            else {
                enemies[i].prefab.transform.Translate(0, 0, -(float)enemies[i].speed * 0.1f, Space.World);
            }
        }
    }
}
