using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickerController : MonoBehaviour
{
    public Light2D lightSource;

    private float timer = 0f;
    public float interval = 0.5f;
    private bool isIncreasing = true;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            if (isIncreasing)
            {
                lightSource.intensity += 0.25f;

                if (lightSource.intensity >= 2)
                {
                    lightSource.intensity = 2;
                    isIncreasing = false;
                }
            }
            else
            {
                lightSource.intensity -= 0.25f;

                if (lightSource.intensity <= 1)
                {
                    lightSource.intensity = 1;
                    isIncreasing = true;
                }
            }
            timer -= interval;
        }
    }
}
