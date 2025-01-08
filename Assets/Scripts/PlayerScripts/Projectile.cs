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
    public float fireRate;

    [Header("LayerMasks")]
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    [Header("ParticleSystem")]
    public ParticleSystem impactParticles;

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
            collision.collider.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }

        var hitLayer = 1 << collision.gameObject.layer;
        if (hitLayer == groundLayer || hitLayer == enemyLayer)
        {
            Vector3 offset = collision.contacts[0].normal * 0.25f;
            Vector3 spawnPosition = transform.position + offset;
            ParticleSystem instantiatedImpact = Instantiate(impactParticles, spawnPosition, Quaternion.identity);
            instantiatedImpact.Play();
            Destroy(instantiatedImpact.gameObject, instantiatedImpact.main.duration);
            Destroy(gameObject);
        }
    }
}
