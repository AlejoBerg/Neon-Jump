using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] platformsReference;
    [SerializeField] private PlayerController playerRef;

    private int usedPlatform = 0;
    private int lastRecycledObject = 0;

    private void Awake()
    {
        lastRecycledObject = platformsReference.Length - 1;
        playerRef.OnCollisionWithPlatform += OnCollisionWithPlatformHandler;
    }

    private void RecyclePlatform()
    {
        if (usedPlatform < platformsReference.Length)
        {
            platformsReference[usedPlatform].transform.position = platformsReference[lastRecycledObject].transform.position + new Vector3(0, 0, 4);
            lastRecycledObject = usedPlatform;
            usedPlatform += 1;
        }
        else
        {
            usedPlatform = 0;
            platformsReference[usedPlatform].transform.position = platformsReference[lastRecycledObject].transform.position + new Vector3(0, 0, 4);
            lastRecycledObject = usedPlatform;
            usedPlatform += 1;
        }
    }

    private void OnCollisionWithPlatformHandler()
    {
        RecyclePlatform();
    }
}
