using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerCollider : MonoBehaviour
{
    Coroutine runningCoroutine = null;
    int countCoroutine = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == "human")
        {
            Debug.Log("human");
            //dialogue.street_score[1]++;
                countCoroutine++;
        }
        else if (other.transform.parent.tag == "Smoking"
              || other.transform.parent.tag == "Demon")
        {
            //dialogue.street_score[1]+= 5;
            countCoroutine += 5;
        } else if(other.transform.parent.tag == "Dance")
        {
            countCoroutine += 10;
        }

        if (runningCoroutine == null)
        {
            runningCoroutine = StartCoroutine("AddScore");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.tag == "human")
        {
            countCoroutine--;
        }
        else if (other.transform.parent.tag == "Smoking"
              || other.transform.parent.tag == "Demon")
        {
            countCoroutine -= 5;
        }
        else if (other.transform.parent.tag == "Dance")
        {
            countCoroutine -= 10;
        }


        if (countCoroutine <= 0 && runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
            runningCoroutine = null;
        }

    }

    IEnumerator AddScore()
    {
        Debug.Log("cor in");
        yield return new WaitForSeconds(3.0f);
        int scoreforce = countCoroutine;
        Debug.Log("1count = " + countCoroutine + ", covidWeight = " + GameManager.covidWeight);
        while (countCoroutine > 0)
        {
            GameManager.covidWeight += scoreforce;
            scoreforce += countCoroutine;
            Debug.Log("count = " + countCoroutine + ", covidWeight = " + GameManager.covidWeight);
            yield return new WaitForSeconds(1.0f);
        }
    }
}