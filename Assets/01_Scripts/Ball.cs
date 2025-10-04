using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 7f;
    private Rigidbody2D rb;
    private Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnBall();
    }
    public void SpawnBall()
    {
        transform.position = Vector2.zero;
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        direction = new Vector2(x, y).normalized;

        rb.velocity = direction * speed;
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = new Vector2(direction.x, -direction.y).normalized;
            rb.velocity = direction * speed;
        }

        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            float hitFactor = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
            float dirX = collision.gameObject.CompareTag("Player1") ? 1 : -1;
            direction = new Vector2(dirX, hitFactor).normalized;

            rb.velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoalLeft") || collision.CompareTag("GoalRight"))
        {
            rb.velocity = Vector2.zero;
            transform.position = Vector2.zero;
            Invoke(nameof(SpawnBall), 0.1f);
        }
    }
}