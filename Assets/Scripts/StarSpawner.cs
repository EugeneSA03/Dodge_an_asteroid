using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject player;

    [SerializeField] private Gradient redStarColor;
    [SerializeField] private Gradient yellowStarColor;
    [SerializeField] private Gradient whiteStarColor;
    [SerializeField] private Gradient blueStarColor;

    [SerializeField] private Color redCoreColor;
    [SerializeField] private Color yellowCoreColor;
    [SerializeField] private Color whiteCoreColor;
    [SerializeField] private Color blueCoreColor;

    [SerializeField] private Color redLightColor;
    [SerializeField] private Color yellowLightColor;
    [SerializeField] private Color whiteLightColor;
    [SerializeField] private Color blueLightColor;

    public static List<Star> stars;
    private System.Random random = new System.Random();

    public class Star {
        public GameObject prefab;

        public ParticleSystem ps;
        public ParticleSystem.ShapeModule psShape;
        public ParticleSystem.MainModule psMain;
        public ParticleSystem.ColorOverLifetimeModule psColorOLT;

        public Renderer coreRender;

        public Light starLight;

        public Star(GameObject _prefab) {
            prefab = _prefab;

            ps = prefab.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
            psShape = ps.shape;
            psMain = ps.main;
            psColorOLT = ps.colorOverLifetime;
            starLight = prefab.GetComponentInChildren<Light>();

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

            float lScale = random.Next(60, 100);

            //Set random star color
            switch (random.Next(0,4)) {
                //Star color RED
                case 0: 
                    tStar.psColorOLT.color = redStarColor;
                    tStar.coreRender.material.color = redCoreColor;
                    tStar.starLight.color = redLightColor;
                    break;
                //Star color YELLOW
                case 1:
                    tStar.psColorOLT.color = yellowStarColor;
                    tStar.coreRender.material.color = yellowCoreColor;
                    tStar.starLight.color = yellowLightColor;
                    break;
                //Star color WHITE
                case 2: 
                    tStar.psColorOLT.color = whiteStarColor;
                    tStar.coreRender.material.color = whiteCoreColor;
                    tStar.starLight.color = whiteLightColor;
                    break;
                //Star color BLUE
                case 3: 
                    tStar.psColorOLT.color = blueStarColor;
                    tStar.coreRender.material.color = blueCoreColor;
                    tStar.starLight.color = blueLightColor;
                    break;
            }

            tStar.prefab.transform.position = new Vector3((random.Next(0, 2) * 2 - 1) * random.Next(170, 300), random.Next(-30, 30), this.transform.position.z);
            tStar.prefab.transform.localScale = new Vector3(lScale, lScale, lScale);
            tStar.psShape.radius = lScale;
            tStar.ps.time = 6.0f;
            tStar.psMain.startSize = lScale;

            stars.Add(tStar);
        }

        for (int i = 0; i < stars.Count; i++) {
            stars[i].prefab.transform.LookAt(player.transform);
        }
    }
}
