using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    public int platformPoolSize = 50;
    public GameObject platformPrefab;
    public float spawnRate = 4f;
    public float platformMin = 2f;
    public float platformMax = 4f;

    private GameObject[] platforms;
    private Vector3 objectPoolPosition = new Vector3(0, 0, 0);
    private float timeSinceLastSpawned;
    private int currentPlatform = 0;


    void Start()
    {
        platforms = new GameObject[platformPoolSize];
        for (int i = 0; i < platformPoolSize; i++)
        {
            platforms[i] = (GameObject)Instantiate(platformPrefab, objectPoolPosition, Quaternion.identity);
            objectPoolPosition += new Vector3(0, 0, 2);
        }
    }


    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnZPosition = platforms[currentPlatform].transform.position.z + 2;
            platforms[currentPlatform].transform.position = new Vector3(0, 0, spawnZPosition);
            currentPlatform++;
            if (currentPlatform >= platformPoolSize)
            {
                currentPlatform = 0;
            }
        }
    }
}