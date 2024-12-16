using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cam Parameter")]
    [SerializeField] private Camera cam;
    [SerializeField] private Transform player;
    public float yThreshold;
    public float xThreshold;
    public Vector3 mousePos;

    // Start is called before the first frame update
    private void Awake()
    {
        xThreshold = 4f;
        yThreshold = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        AimLogic();
    }

    private void AimLogic()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2;

        targetPos.x = Mathf.Clamp(targetPos.x, -xThreshold + player.position.x, xThreshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -yThreshold + player.position.y, yThreshold + player.position.y);

        this.transform.position = targetPos;
    }
}
