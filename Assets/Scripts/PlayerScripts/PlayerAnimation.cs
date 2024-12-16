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
            animator.SetFloat("Facing", -1);
        }
        else
        {
            animator.SetFloat("Facing", 1);
        }
        
        animator.SetFloat("Speed", Mathf.Clamp(playerController.GetVelocityX(), -1, 1));
        animator.SetBool("Grounded", playerController.GetIsGrounded());
    }
}
