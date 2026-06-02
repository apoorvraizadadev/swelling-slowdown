using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public PlayerDamage pd;
    public bool touching;
    // Start is called before the first frame update
    void Start()
    {
        pd = GameObject.Find("Player").GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            pd.Damage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touching = true;
            pd = collision.gameObject.GetComponent<PlayerDamage>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touching = false;
        }
    }
}
