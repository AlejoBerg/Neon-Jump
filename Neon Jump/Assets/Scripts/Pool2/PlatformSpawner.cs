using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    ObjectPooler  objectPooler;
    private float Life = 0.2f;
    private int temp = 0;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }   
    IEnumerator ReturnToPoolCourrutine(float _time)
    {
        yield return new WaitForSeconds(_time);
        objectPooler.SpawnFromPool("Platform", Quaternion.identity);
    }
    private void FixedUpdate()
    {
        if(temp < 10)
        {
            temp++;
            StartCoroutine(ReturnToPoolCourrutine(0));
        }
        StartCoroutine(ReturnToPoolCourrutine(Life));
        Life++;
    }
}
