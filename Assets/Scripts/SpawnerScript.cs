using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
    public GameObject obj = null;
    public int index = 0;
    public float speed = 0f;
}

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab = null;
    public uint maxEnemiesCount = 1;

    private GameObject spawner = null;
    private Enemy[] enemies = null;
    private Enemy enemyTemp = null;
    private System.Random rand = null;

    // Start is called before the first frame update
    void Start()
    {
        spawner = this.gameObject;
        enemies = new Enemy[maxEnemiesCount];
        enemyTemp = new Enemy();
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (enemies.Length < maxEnemiesCount) {
            EnemyCreate(enemies.Length);
        }
        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i].obj.transform.position.z > -20) {
                enemies[i].obj.transform.Translate(0, 0, enemies[i].speed);
            }
            else {
                EnemyDelete(i);
            }
        }
    }

    public void EnemyCreate(int index) {
        enemyTemp.obj = Instantiate(enemyPrefab, spawner.transform.position, Quaternion.identity);
        enemyTemp.speed = rand.Next(6, 60) / -10;
        enemyTemp.index = enemies.Length;
        enemies[enemies.Length] = enemyTemp;
    }

    public void EnemyDelete(int index) {
        Destroy(enemies[index].obj);
        enemies[index] = null;
        EnemyCreate(index);
    }
}
