using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float xMovement;
    public float targetX;
    [Range(0f, 1f)] public float friction;
    public float jumpHeight;
    public Transform foot;
    public float checkRadius;
    public LayerMask ground;
    public float size = 1;
    public Vector2 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one * size;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (Physics2D.OverlapCircle(foot.position, checkRadius, ground))
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpHeight);
            }
        }
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            targetX = Input.GetAxisRaw("Horizontal") * speed;
        }

        else
        {
            targetX = 0;
        }
        xMovement += (targetX - xMovement) * (1 - friction);
        rb.velocity = new Vector2(xMovement, rb.velocity.y);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(foot.position, checkRadius);
    }

    public void Restart()
    {
        transform.position = startPosition;
        xMovement = 0;
        targetX = 0;
    }
}
