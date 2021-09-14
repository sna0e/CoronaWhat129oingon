using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject maskPlayer;
    public GameObject noMaskPlayer;
    public static bool maskState;
    // Start is called before the first frame update
    void Start()
    {
        maskState = true;
        maskPlayer.SetActive(true);
        noMaskPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.R))
        {
            if (maskState == true)
            {
                maskPlayer.SetActive(false);
                noMaskPlayer.SetActive(true);
                maskState = false;
                noMaskPlayer.transform.position = maskPlayer.transform.position;
                noMaskPlayer.transform.rotation = maskPlayer.transform.rotation;
            }
        }
        */
    }
}
