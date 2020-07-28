using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    SpawnPlatforms spawnPlatforms;


    // Start is called before the first frame update
    void Start()
    {
        spawnPlatforms = GetComponent<SpawnPlatforms>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTriggerEntered()
    {
        spawnPlatforms.MovePlatform();
    }
}
