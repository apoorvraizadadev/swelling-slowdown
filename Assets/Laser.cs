using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    [Range(0, 1)] public float value = 1;
    public float targetVal = 1;
    public float smoothness = 10;
    public bool inProgress;
    public float interval = 2;
    public BoxCollider2D bc;
    public PlayerDamage pd;
    public bool touching;
    public float delay = 0;
    public bool wait;
    public bool waitP;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position - ((transform.localScale.y / 2) * Vector3.up);
        end = transform.position + ((transform.localScale.y / 2) * Vector3.up);
        targetVal = 1;
        inProgress = false;
        bc = GetComponent<BoxCollider2D>();
        pd = GameObject.Find("Player").GetComponent<PlayerDamage>();
        wait = false;
        waitP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!wait) && (!waitP))
        {
            StartCoroutine(Wait());
        }
        if (wait)
        {
            if (!inProgress)
            {
                StartCoroutine(OnOff());
            }
            Display(start, Vector2.Lerp(start, end, value));
            value += (targetVal - value) / smoothness;
            if (Mathf.Abs(value - targetVal) < 0.01f)
            {
                value = targetVal;
            }

            if (value < 0.15f)
            {
                bc.enabled = false;
            }

            else
            {
                bc.enabled = true;
            }

            if (touching)
            {
                pd.Damage();
            }
        }
    }

    public void Display(Vector2 s, Vector2 e)
    {
        transform.localPosition = new Vector2(((s.x + e.x) / 2), ((s.y + e.y) / 2));
        transform.localScale = new Vector2(transform.localScale.x, Mathf.Abs(s.y - e.y));
    }

    IEnumerator OnOff()
    {
        inProgress = true;
        if (value == 0)
        {
            targetVal = 1;
        }

        else
        {
            targetVal = 0;
        }

        yield return new WaitForSeconds(interval);

        inProgress = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touching = true;
            pd = collision.gameObject.GetComponent<PlayerDamage>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touching = false;
        }
    }

    IEnumerator Wait()
    {
        waitP = true;

        yield return new WaitForSeconds(delay);

        waitP = false;
        wait = true;
    }
}
