using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public PlayerDamage pd;
    public bool touching;
    public float interval;
    public GameObject bullet;
    public bool inProgress = false;
    public GameObject p;
    public float distanceT = 25;
    public Transform firePoint;

    private void Start()
    {
        p = GameObject.Find("Player");
        firePoint = transform.Find("FirePoint");
        pd = GameObject.Find("Player").GetComponent<PlayerDamage>();

    }

    void Update()
    {
        if (!inProgress && Vector3.Distance(p.transform.position, transform.position) < distanceT)
        {
            StartCoroutine(Shoot());
        }
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

    IEnumerator Shoot()
    {
        inProgress = true;
        GameObject bulletObj;
        bulletObj = Instantiate(bullet, firePoint.position, Quaternion.identity);
        bulletObj.GetComponent<Bullet>().dir = new Vector2(p.transform.position.x - firePoint.position.x, p.transform.position.y - firePoint.position.y).normalized;
        yield return new WaitForSeconds(interval);
        inProgress = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceT);
    }
}
