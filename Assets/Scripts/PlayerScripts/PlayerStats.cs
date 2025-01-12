using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Animator animator;
    public int health = 5;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage, Collision2D collision)
    {
        health -= damage;
        animator.SetTrigger("TakeDamage");
        playerController.Knockback(new Vector2(0, 1), 7);
        if (health <= 0)
        {
            Die();
        }
        else
        {
            
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
    }
}
