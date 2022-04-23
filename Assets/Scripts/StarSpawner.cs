using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject prefab;

    private List<GameObject> stars;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        stars = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (stars.Count < 1) {
            GameObject temp = Instantiate(prefab);

            temp.transform.position = new Vector3((random.Next(0, 2) * 2 - 1) * random.Next(50, 150), random.Next(-30, 30), this.transform.position.z);



            stars.Add(temp);
        }    
    }
}
