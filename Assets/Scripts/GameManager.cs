using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject helicopterPrefab;
    public Transform[] helicopterSpawnPoints;
    public float helicopterSpawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnHelicopters());
    }

    IEnumerator SpawnHelicopters()
    {
        while (true)
        {
            Transform spawnPoint = helicopterSpawnPoints[Random.Range(0, helicopterSpawnPoints.Length)];
            GameObject helicopter = Instantiate(helicopterPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(helicopterSpawnInterval);
        }
    }
}
