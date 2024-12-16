using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform staff;
    private PlayerController playerController;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
    private void FixedUpdate()
    {
        if(staff.rotation.eulerAngles.z > 90 && staff.rotation.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        animator.SetFloat("Speed", playerController.GetVelocityX());
        animator.SetBool("Grounded", playerController.GetIsGrounded());
    }
}
