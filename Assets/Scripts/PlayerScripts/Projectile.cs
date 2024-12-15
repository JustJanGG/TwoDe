using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Stats")]
    private Rigidbody2D rigidBody;
    public float force;
    public float timeToLive;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;

        rigidBody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        Destroy(gameObject, timeToLive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            //collision.gameObject.GetComponent<EnemyStats>().takeDamage(damage);
        }
    }
}
