using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;       
        
    }

    public static ObjectPooler Instance;


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
    private Vector3 objectPoolPosition = new Vector3(0, 0, 0);

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                Debug.Log(objectPoolPosition);
                GameObject obj = (GameObject) Instantiate(pool.prefab, objectPoolPosition, Quaternion.identity);
                obj.SetActive(false);               
                objectPool.Enqueue(obj);
                var reference = objectPool.Peek();
                reference.transform.position = objectPoolPosition;
                objectPoolPosition += new Vector3(0, 0, 2);                
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log(tag + "No existe");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = objectPoolPosition;
        objectPoolPosition += new Vector3(0, 0, 2);
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }


        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
