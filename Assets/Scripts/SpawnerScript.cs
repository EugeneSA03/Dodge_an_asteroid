using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private class Enemy {
        public GameObject prefab = null;
        public double speed = 0;
        public float lifeTime = 0f;
    }

    public GameObject prefab = null;
    public int maxEnemies = 1;

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
            enemyTemp.speed = random.NextDouble();
            enemyTemp.prefab = Instantiate(prefab);
            enemyTemp.prefab.transform.position = new Vector3(random.Next(-70, 70), random.Next(-35, 35), spawner.transform.position.z);
            enemyTemp.prefab.name = enemies.Count.ToString();
            enemies.Add (enemyTemp);
        }
        for (int i = 0; i < enemies.Count; i++) {
            if (enemies[i].prefab.transform.position.z < -20) {
                DestroyImmediate (enemies[i].prefab, true);
                enemies.RemoveAt (i);
            }
            else {
                enemies[i].prefab.transform.Translate(0, 0, (float)enemies[i].speed * 0.1f);
            }
        }
    }
}
