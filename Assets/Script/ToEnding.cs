using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEnding : MonoBehaviour
{

    public Rigidbody player;
    private void OnTriggerEnter(Collider collision)
    {

        SceneManager.LoadScene("Ending");
    }
 
}
