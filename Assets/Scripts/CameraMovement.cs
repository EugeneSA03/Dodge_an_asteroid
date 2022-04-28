using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam = null;
    [SerializeField] private Vector3 startPosition = Vector3.zero;
    [SerializeField] private Vector3 endPosition = Vector3.zero;

    [SerializeField] private float moveSpeed = 0.01f;
    [SerializeField] private float moveLerp = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        cam.transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (moveLerp < 1) {
            cam.transform.position = Vector3.Slerp(startPosition, endPosition, moveLerp);
            if (moveLerp > 0.8f) {
                moveLerp -= moveSpeed / 3;
            }
            moveLerp += moveSpeed;
        }
    }
}
