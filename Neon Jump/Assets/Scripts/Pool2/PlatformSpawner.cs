using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    ObjectPooler  objectPooler;


    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Platform", Quaternion.identity);
    }
}
