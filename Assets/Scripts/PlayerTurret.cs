using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Camera mainCamera;
    public float minRotation = -72.5f; // Left boundary (145-degree range centered at 0)
    public float maxRotation = 72.5f; // Right boundary

    public static int score = 0; // Player score
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    void Update()
    {
        AimTowardsMouse();
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

    void AimTowardsMouse()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mousePosition.x;
        float direction = transform.position.x - mouseX; 
        float angle = Mathf.Lerp(minRotation, maxRotation, (direction + 1) / 2); 
        transform.rotation = Quaternion.Euler(0, 0, angle); 
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, transform.rotation); 
    }

    public static void IncreaseScore()
    {
        score++;
        GameObject.FindObjectOfType<PlayerTurret>().UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
