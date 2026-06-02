using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerController pc;
    public SizeController sc;
    public float amount;
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        sc = GetComponent<SizeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if (pc.size <= 1)
        {
            pc.Restart();
            sc.Restart();
        }

        else
        {
            sc.bigSize -= amount;
            sc.targetSize = sc.bigSize;
        }
    }
}
