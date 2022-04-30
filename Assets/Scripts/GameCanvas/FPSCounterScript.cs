using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FPSCounterScript : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private string fps;
    // Start is called before the first frame update
    void Start()
    {
        txt = this.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        fps = Mathf.RoundToInt(1.0f / Time.deltaTime).ToString();
    }

    private void FixedUpdate() {
        txt.SetText("FPS: " + fps);
    }
}
