using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paratrooper : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float moveSpeed = 0.5f;
    private bool hasLanded = false;
    private bool isClimbing = false;
    private Transform turret;
    private Rigidbody2D rb;
    public float gameOverHeight = 4.5f; // Height at which game over is triggered

    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("Turret").transform;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        gameObject.tag = "Enemy"; // Ensure Paratrooper is tagged as Enemy
    }

    void Update()
    {
        if (hasLanded)
        {
            MoveTowardsTurret();
        }

        if (transform.position.y >= gameOverHeight)
        {
            GameOver();
        }
    }

    void MoveTowardsTurret()
    {
        if (!isClimbing)
        {
            Vector2 direction = (turret.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            hasLanded = true;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
        else if (collision.collider.CompareTag("Paratrooper"))
        {
            isClimbing = true;
            transform.position += new Vector3(0, 0.5f, 0); 
        }
        else if (collision.collider.CompareTag("Turret"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over! The paratroopers have stacked too high.");
        Time.timeScale = 0;
    }
}