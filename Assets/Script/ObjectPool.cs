using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject poolalbeObject;
    public int objectpoolCount;
    Queue<GameObject> objectPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectpoolCount; i++)
        {
            CreatePooledObject();
        }
        for(int i = 0; i < objectpoolCount; i++)
        {
            GameObject pooledObject = this.Dequeue();
            //pooledObject.transform.position = transform.position;
        }
    }

    void CreatePooledObject()
    {
        GameObject temp = Instantiate(poolalbeObject);
        temp.transform.SetParent(this.gameObject.transform);
        temp.GetComponent<NPC>().Init(this);
        temp.SetActive(false);
        objectPool.Enqueue(temp);
    }

    // Get Object
    public GameObject Dequeue()
    {
        if (objectPool.Count <= 0)
        {
            CreatePooledObject();
        }

        GameObject dequeueObject = objectPool.Dequeue();
        dequeueObject.GetComponent<NPC>().CleanUp();
        dequeueObject.SetActive(true);
        return dequeueObject;
    }
    // Back to pool
    public void Enqueue(GameObject _enqueueObject)
    {
        _enqueueObject.SetActive(false);
        objectPool.Enqueue(_enqueueObject);
        GameObject pooledObject = this.Dequeue();
    }
}
