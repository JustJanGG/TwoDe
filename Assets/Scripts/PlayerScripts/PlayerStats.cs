using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Animator animator;
    public int health = 3;
    private PlayerController playerController;
    public GameObject[] hearts;
    private bool alive = true;
    private float invincibleTime = 0.5f;
    private float lastTimeHit;
    public GameObject gameOverScreen;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeHit = Time.time;
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage, Collision2D collision)
    {
        if (!alive || lastTimeHit+invincibleTime > Time.time)
        {
            return;
        }
        lastTimeHit = Time.time;
        hearts[health - 1].SetActive(false);
        health -= damage;
        animator.SetTrigger("TakeDamage");
        playerController.Knockback(new Vector2(0, 1), 7);
        if (health <= 0)
        {
            alive = false;
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Player died");
        gameOverScreen.SetActive(true);
        player.SetActive(false);
        Cursor.visible = true;
    }
}
