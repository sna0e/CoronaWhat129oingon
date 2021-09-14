using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    public Rigidbody player;
    public bool triggerState;


    private void OnTriggerEnter(Collider collision)
    {
        triggerState = true;

       /* 바로 실행되는 거
        * if (triggerState && Input.GetKey(KeyCode.F))
        {
            player.transform.position = new Vector3(
                destination.transform.position.x,
                destination.transform.position.y,
                destination.transform.position.z
                );
        }*/

    }

    private void OnTriggerStay(Collider collision)
    {
        StartCoroutine("Teleporter");

        if (triggerState && Input.GetKeyDown(KeyCode.F))
        {
            player.transform.position = new Vector3(
                destination.transform.position.x,
                destination.transform.position.y,
                destination.transform.position.z
                );
        }
        
    }
    
    IEnumerable Teleporter()
    {
        yield return null;

        {
            player.transform.position = new Vector3(
                destination.transform.position.x,
                destination.transform.position.y,
                destination.transform.position.z
                );
        }

    }
}

