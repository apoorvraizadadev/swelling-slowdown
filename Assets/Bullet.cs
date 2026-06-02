using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerDamage pd;
    public Vector2 dir;
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pd = GameObject.Find("Player").GetComponent<PlayerDamage>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
            collision.gameObject.GetComponent<PlayerDamage>().Damage();
        }
        Destroy(gameObject);
    }
}
