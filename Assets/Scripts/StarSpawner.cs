using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject prefab;

    public Gradient redStarColor;
    public Gradient yellowStarColor;
    public Gradient whiteStarColor;
    public Gradient blueStarColor;

    private List<Star> stars;
    private System.Random random = new System.Random();

    public class Star {
        public GameObject prefab;

        public ParticleSystem ps;
        public ParticleSystem.ShapeModule psShape;
        public ParticleSystem.MainModule psMain;
        public ParticleSystem.ColorOverLifetimeModule psColorOLT;

        public Renderer coreRender;

        public Star(GameObject _prefab) {
            prefab = _prefab;

            ps = prefab.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            psShape = ps.shape;
            psMain = ps.main;
            psColorOLT = ps.colorOverLifetime;

            coreRender = prefab.transform.GetChild(1).gameObject.GetComponent<Renderer>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        stars = new List<Star>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (stars.Count < 1) {
            GameObject temp = Instantiate(prefab);

            Star tStar = new Star(temp);
            
            float lScale = random.Next(20, 40);

            //Set random star color
            switch (random.Next(0,4)) {
                //Star color RED
                case 0: 
                    tStar.psColorOLT.color = redStarColor;
                    tStar.coreRender.material.color = new Color(80, 0, 0);
                    break;
                //Star color YELLOW
                case 1:
                    tStar.psColorOLT.color = yellowStarColor;
                    tStar.coreRender.material.color = new Color(80, 80, 0);
                    break;
                //Star color WHITE
                case 2: 
                    tStar.psColorOLT.color = whiteStarColor;
                    tStar.coreRender.material.color = new Color(80, 80, 80);
                    break;
                //Star color BLUE
                case 3: 
                    tStar.psColorOLT.color = blueStarColor;
                    tStar.coreRender.material.color = new Color(0, 0, 80);
                    break;
            }

            tStar.prefab.transform.position = new Vector3((random.Next(0, 2) * 2 - 1) * random.Next(50, 150), random.Next(-30, 30), this.transform.position.z);
            tStar.prefab.transform.localScale = new Vector3(lScale, lScale, lScale);
            tStar.psShape.radius = lScale;
            tStar.ps.time = 6.0f;
            tStar.psMain.startSize = lScale;

            stars.Add(tStar);
        }
    }
}
