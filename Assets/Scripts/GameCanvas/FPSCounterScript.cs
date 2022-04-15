using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FPSCounterScript : MonoBehaviour
{
    private Text txt;
    private string fps;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.gameObject.GetComponent<Text>();
        txt.fontSize = Screen.height / 20;
    }


    void Update()
    {
        fps = Mathf.RoundToInt(1.0f / Time.deltaTime).ToString();
    }

    private void FixedUpdate() {
        txt.text = "FPS: " + fps;
    }
}
