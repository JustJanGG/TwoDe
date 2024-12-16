using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShowCrosshair();
    }

    private void ShowCrosshair()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}
