using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{

    public List<GameObject> platform;
    //public GameObject[] platforms = new GameObject[4];    Array
    

    private float offset = 2f;




    private void Awake()
    {
       
    }

    void Start()
    {   

        //Aca marcariamos cada espacio del Array
        
        if (platform != null && platform.Count > 0)
        {
            platform = platform.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovePlatform()
    {
        GameObject movePlatform = platform[0];
        float posY = transform.position.y + 1f;
        platform.Remove(movePlatform);
        float posZ = platform[platform.Count - 1].transform.position.z + offset;
        movePlatform.transform.position = new Vector3(Random.Range(-1f,3f), posY + 1, posZ);

        platform.Add(movePlatform);

    }


}
