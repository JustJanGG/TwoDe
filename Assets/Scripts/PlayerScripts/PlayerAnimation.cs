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
        if (staff.rotation.eulerAngles.z > 90 && staff.rotation.eulerAngles.z < 270)
        {
            animator.SetFloat("Facing", -1);
            staff.localScale = new Vector3(1, -1, 1);
            staff.localPosition = new Vector3(0.1f, 0.015f, -0.01f);
  
        }
        else
        {
            animator.SetFloat("Facing", 1);
            staff.localScale = new Vector3(1, 1, 1);
            staff.localPosition = new Vector3(-0.1f, 0.015f, -0.01f); 
        }

        animator.SetFloat("Speed", Mathf.Clamp(playerController.GetVelocityX(), -1, 1));
        animator.SetBool("Grounded", playerController.GetIsGrounded());
        float verticalSpeed = Mathf.Clamp(playerController.GetVelocityY(), -2, 2);
        if (verticalSpeed < 2 && verticalSpeed > -2)
        {
            verticalSpeed = 0;
        }
        animator.SetFloat("VerticalSpeed", verticalSpeed);
    }
}
