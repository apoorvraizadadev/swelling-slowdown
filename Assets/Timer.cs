using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public string display;
    public TMP_Text text;
    public bool active = false;
    public bool firstTouch;
    // Start is called before the first frame update
    void Start()
    {
        active = false;
        firstTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !firstTouch && !active)
        {
            firstTouch = true;
            active = true;
        }
        if (active)
        {
            time += Time.deltaTime;
        }
        text.text = TimeSpan.FromSeconds(time).ToString("mm\\:ss\\.fff");
    }
}
