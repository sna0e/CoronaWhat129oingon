using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    float setTime = 600;
    public Text Count;
    bool startTime = false;

    void Update()
    {
        if (startTime == false)
        {
            startTime = true;
            if (setTime > 0)
            {
                StartCoroutine(CountDown((setTime - 1)));
                setTime--;
            }
            else if (setTime == 0)
            {
                Debug.Log("Time Over");
            }
        }
    }

    IEnumerator CountDown(float msg)
    {
        yield return new WaitForSeconds(1.0f);

        int minutes = Mathf.FloorToInt(msg / 60F);
        int seconds = Mathf.FloorToInt(msg - minutes * 60);
        string timer = string.Format("{0:0}:{1:00}", minutes, seconds);
        GameManager.timer = timer;
        Count.text = timer;
        startTime = false;
    }
}
