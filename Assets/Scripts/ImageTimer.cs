using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ImageTimer : MonoBehaviour
{
    public float maxTime;
    private Image img;
    private float currentTime;
    public bool tick;
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tick = false;
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            tick = true;
            currentTime = 0;
        }

        img.fillAmount = currentTime / maxTime;
    }
}
