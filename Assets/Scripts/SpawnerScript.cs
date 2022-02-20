using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private class Enemy {
        public GameObject prefab = null;
        public float speed = 0;
        
    }

    public GameObject prefab = null;
    public int maxEnemies = 1;
    public float maxEnemyScale = 3;
    public uint maxEnemySpeed = 3;
    public uint minEnemySpeed = 3;

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
            enemyTemp.prefab = Instantiate(prefab);

            enemyTemp.speed = random.Next((int)minEnemySpeed, (int)maxEnemySpeed);

            float eScale = maxEnemyScale / enemyTemp.speed;

            enemyTemp.prefab.GetComponent<Rigidbody>().mass = eScale;
            enemyTemp.prefab.transform.localScale = new Vector3(eScale * 100, eScale * 100, eScale * 100);

            enemyTemp.prefab.transform.position = new Vector3(random.Next(-10, 10), random.Next(-15, 15), spawner.transform.position.z);

            enemies.Add (enemyTemp);
        }
        for (int i = 0; i < enemies.Count; i++) {
            if (enemies[i].prefab.transform.position.z < -20 ||
                Mathf.Abs(enemies[i].prefab.transform.position.x) > 70 ||
                Mathf.Abs(enemies[i].prefab.transform.position.y) > 35) {
                DestroyImmediate (enemies[i].prefab, true);
                enemies.RemoveAt (i);
            }
            else {
                enemies[i].prefab.transform.Translate(0, 0, (float)enemies[i].speed * 0.1f);
            }
        }
    }
}
