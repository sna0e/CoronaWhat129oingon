using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Vector3 spawnPoint;
    Vector3 arrivePoint;
    bool distance;
    float moveSpeed;

    ObjectPool pool;

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, arrivePoint, moveSpeed);
        if (transform.localPosition.x == arrivePoint.x) pool.Enqueue(gameObject);
    }
    public void Init(ObjectPool _pool)
    {
        moveSpeed = Random.Range(0.0001f, 0.0005f);
        spawnPoint = new Vector3(0, -0.0067f, 0);
        spawnPoint.z = Random.Range(GameObject.Find("SpawnPoint").transform.GetChild(0).localPosition.z
                                  , GameObject.Find("SpawnPoint").transform.GetChild(1).localPosition.z);
        spawnPoint.x = Random.Range(GameObject.Find("SpawnPoint").transform.GetChild(2).localPosition.x
                                   ,GameObject.Find("SpawnPoint").transform.GetChild(1).localPosition.x - 0.05f);
        //Debug.Log(spawnPoint);
        transform.localPosition = spawnPoint;
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        if (Random.Range(0, 2) == 0)
        {
            distance = false;
            transform.Rotate(new Vector3(0, 1, 0), 180.0f);
            arrivePoint = new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(0).localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            distance = true;
            arrivePoint = new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(2).localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        pool = _pool;
    }

    public void CleanUp()
    {
        //Debug.LogError("√ ±‚»≠");
        if (distance)
        {
            distance = false;
            arrivePoint = new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(0).localPosition.x, transform.localPosition.y, transform.localPosition.z);

        }
        else
        {
            distance = true;
            arrivePoint = new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(2).localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        transform.Rotate(new Vector3(0, 1, 0), 180.0f);
        spawnPoint = transform.localPosition;
        spawnPoint.z = Random.Range(GameObject.Find("SpawnPoint").transform.GetChild(0).localPosition.z
                                  , GameObject.Find("SpawnPoint").transform.GetChild(1).localPosition.z);
        transform.localPosition = spawnPoint;

        if(distance)
            arrivePoint = new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(2).localPosition.x, transform.localPosition.y, transform.localPosition.z);
        else new Vector3(GameObject.Find("SpawnPoint").transform.GetChild(0).localPosition.x, transform.localPosition.y, transform.localPosition.z);

        moveSpeed = Random.Range(0.0001f, 0.0005f);
    }
}
