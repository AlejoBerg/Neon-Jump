using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    ObjectPooler  objectPooler;
    private float Life = 1f;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }   
    IEnumerator ReturnToPoolCourrutine()
    {
        yield return new WaitForSeconds(Life);
        objectPooler.SpawnFromPool("Platform", Quaternion.identity);
    }
    private void FixedUpdate()
    {
       StartCoroutine(ReturnToPoolCourrutine());
       Life++;
    }
}
