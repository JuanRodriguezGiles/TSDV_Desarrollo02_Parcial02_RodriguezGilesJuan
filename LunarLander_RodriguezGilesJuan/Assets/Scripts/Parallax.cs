using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght;
    private float startPos;
    private Camera camera;
    public float parallaxAmmount;
    void Start()
    {
        camera = Camera.main;
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxAmmount;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
