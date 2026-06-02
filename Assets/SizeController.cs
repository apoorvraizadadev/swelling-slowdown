using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    public PlayerController pc;
    public Rigidbody2D rb;
    [HideInInspector] public float targetSize = 1;
    public float bigSize;
    [HideInInspector] public float smallSpeed;
    public float bigSpeed;
    [HideInInspector] public float smallGravity;
    public float bigFriction;
    [HideInInspector] public float smallFriction;
    public float bigGravity;
    public float smoothnessAmount;
    public bool inflated = false;
    public float startBigSize;
    //TODO: CHAMGE FRICTION
    //TODO: CHAMGE FRICTION
    //TODO: CHAMGE FRICTION
    //TODO: CHAMGE FRICTION
    //TODO: CHAMGE FRICTION
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        smallSpeed = pc.speed;
        smallFriction = pc.friction;
        smallGravity = rb.gravityScale;
        startBigSize = bigSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(pc.size - targetSize) < 0.1f)
        {
            if (!inflated)
            {
                targetSize = bigSize;
            }

            else
            {
                targetSize = 1;
            }

            inflated = !inflated;
        }

        if (Mathf.Abs(pc.size - targetSize) < 0.1f)
        {
            pc.size = targetSize;
        }

        pc.size += (targetSize - pc.size) / smoothnessAmount;

        pc.speed = Mathf.Lerp(smallSpeed, bigSpeed, (pc.size - 1) / (bigSize - 1));
        pc.friction = Mathf.Lerp(smallFriction, bigFriction, (pc.size - 1) / (bigSize - 1));
        rb.gravityScale = Mathf.Lerp(smallGravity, bigGravity, (pc.size - 1) / (bigSize - 1));
    }

    public void Restart()
    {
        inflated = false;
        bigSize = startBigSize;
        pc.size = 1;
    }
}
