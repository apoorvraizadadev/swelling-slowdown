using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public List<float> times = new List<float>();
    public List<TMP_Text> texts = new List<TMP_Text>();
    public bool isUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;
        if (GameObject.FindGameObjectsWithTag("ScoreManager").Length < 2)
        {
            DontDestroyOnLoad(this.gameObject);
            isUsed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        texts.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Text"))
        {
            texts.Add(item.GetComponent<TMP_Text>());
        }
        if (isUsed)
        {
            for (int i = 0; i < times.Count; i++)
            {
                if (times[i] == -1)
                {
                    texts[i].text = "";
                }

                else
                {
                    texts[i].text = "Best: " + TimeSpan.FromSeconds(times[i]).ToString("mm\\:ss\\.fff");
                }
            }
        }
    }
}
