using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{

    public List<GameObject> platform;
    private float offset = 5f;



    // Start is called before the first frame update
    void Start()
    {
        if(platform != null && platform.Count > 0)
        {
            platform = platform.OrderBy(p => p.transform.position.z).ToList(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovePlatform()
    {
        GameObject movePlatform = platform[0];
        platform.Remove(movePlatform);
        float newZ = platform[platform.Count - 1].transform.position.z + offset;
        movePlatform.transform.position = new Vector3(0, 0, newZ);
        platform.Add(movePlatform);

    }


}
