using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera cam;

    public Transform subject;

    public Vector2 startPosition;

    float startZ;

    [Range(0f, 1f)] public float parallaxConstant;

    Vector2 travel;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        travel = (Vector2)cam.transform.position - startPosition;
        transform.position = startPosition + (travel * parallaxConstant);
    }
}
