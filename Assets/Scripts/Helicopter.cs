using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject paratrooperPrefab;
    public Transform dropPoint;
    public float dropInterval = 3f;
    public float moveSpeed = 2f;
    public float leftBoundary = -20f;
    public float rightBoundary = 20f;
    private int direction = 1;

    void Start()
    {
        StartCoroutine(DropParatroopers());
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);

        if (transform.position.x >= rightBoundary)
        {
            direction = -1;
            FlipHelicopter();
        }
        else if (transform.position.x <= leftBoundary)
        {
            direction = 1;
            FlipHelicopter();
        }
    }

    void FlipHelicopter()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    IEnumerator DropParatroopers()
    {
        while (true)
        {
            Instantiate(paratrooperPrefab, dropPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(dropInterval);
        }
    }
}