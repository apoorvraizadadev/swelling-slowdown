using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public RectTransform rm;
    public RectTransform lsm;
    [Range(0, 1920)] public float scroll = 0;
    public float targetScroll;
    public float smoothness = 15;
    // Start is called before the first frame update
    void Start()
    {
        targetScroll = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rm.position = new Vector3 (0 - scroll + 960, 540);
        lsm.position = new Vector3 (1920 - scroll + 960, 540);
        scroll += (targetScroll - scroll) / smoothness;
    }

    public void SetScroll(float amount)
    {
        targetScroll = amount;
    }
}
