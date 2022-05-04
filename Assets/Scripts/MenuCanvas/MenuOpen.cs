using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuOpen : MonoBehaviour
{
    private GameObject menu;
    private RectTransform menuRT;

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float moveLerp = 0;

    [SerializeField] private TextMeshProUGUI coinsTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        menu = this.GetComponent<GameObject>();
        menuRT = this.GetComponent<RectTransform>();
        menuRT.anchoredPosition3D = startPosition;

        coinsTxt.SetText(PlayerPrefs.GetInt("Total coins").ToString());
        highScoreTxt.SetText(PlayerPrefs.GetFloat("High score").ToString());
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (moveLerp < 1) {
            menuRT.anchoredPosition3D = Vector3.Lerp(startPosition, endPosition, moveLerp);
            if (moveLerp > 0.8f) {
                moveLerp -= moveSpeed / 3;
            }
            moveLerp += moveSpeed;
        }
    }
}
