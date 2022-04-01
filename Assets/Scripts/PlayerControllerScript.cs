using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{

    public float playerSpeed = 0.1f;

    private GameObject player = null;


    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.RightArrow))
            player.GetComponentInChildren<Transform>().Translate(new Vector3(playerSpeed, 0, 0));
        if (Input.GetKey(KeyCode.UpArrow))
            player.GetComponentInChildren<Transform>().Translate(new Vector3(0, 0, playerSpeed));
        if (Input.GetKey(KeyCode.LeftArrow))
            player.GetComponentInChildren<Transform>().Translate(new Vector3(-playerSpeed, 0, 0));
        if (Input.GetKey(KeyCode.DownArrow))
            player.GetComponentInChildren<Transform>().Translate(new Vector3(0, 0, -playerSpeed));
        player.GetComponentInChildren<Transform>().Translate(new Vector3(Input.acceleration.x * playerSpeed, 0, Input.acceleration.y * playerSpeed));
    }
}
