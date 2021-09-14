using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<GameObject> interactionList;
    Vector3 playerPosition;
    Quaternion playerRotation;
    GameObject player;
    Animator animator;

    private void Awake()
    {
        interactionList = new List<GameObject>();
        GameManager.isSit = false;
        player = GameObject.Find("Player").gameObject;
        animator = player.GetComponent<Animator>();
        animator.SetInteger("Sit", 0);
    }
    private void Update()
    {

        if (interactionList.Count != 0)
        {
            //Debug.Log(interactionList.Count);
            float nearest = 999999.9f;
            GameObject nearestObj = null;
            foreach (GameObject inst in interactionList)
            {
                float distance = Vector3.Distance(player.transform.position, inst.transform.position);
                inst.GetComponent<Outline>().OutlineColor = new Color(1, 1, 1, 0);
                if (distance < nearest)
                {
                    nearest = distance;
                    nearestObj = inst;
                }
            }
            nearestObj.GetComponent<Outline>().OutlineColor = new Color32(106, 255, 7, 255);

            if (Input.GetKeyDown(KeyCode.F))
            {
                foreach(GameObject inst in interactionList)
                {
                    float distance = Vector3.Distance(player.transform.position, inst.transform.position);
                    //Debug.Log(distance);
                    if(distance < nearest)
                    {
                        nearest = distance;
                        nearestObj = inst;
                    }
                }
                if(nearestObj.CompareTag("cafeSeat"))
                {
                    playerPosition = player.transform.position;
                    playerRotation = player.transform.rotation;
                    GameManager.isSit = true;
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    Debug.Log(nearestObj.transform.rotation);
                    Debug.Log(nearestObj.transform.rotation.x + "rotate x");
                    Debug.Log(nearestObj.transform.rotation.y + "rotate y");
                    Debug.Log(nearestObj.transform.rotation.z + "rotate z");
                    player.transform.rotation = Quaternion.Euler(0, nearestObj.transform.rotation.eulerAngles.y + 90, 0);

                    player.transform.localPosition = new Vector3(nearestObj.transform.position.x + 0.004f,
                                                            nearestObj.transform.position.y + 0.0075f,
                                                            nearestObj.transform.position.z + 0.00107f);
                    animator.SetFloat("v", 0);
                    animator.SetFloat("h", 0);
                    animator.SetInteger("Sit", 2);
                    //Debug.Log("성공!");
                    foreach (GameObject inst in interactionList)
                    {
                        inst.GetComponent<Outline>().OutlineColor = new Color(1, 1, 1, 0);
                    }
                    interactionList.Clear();
                } 
                else if (nearestObj.CompareTag("cafeOrder"))
                {
                    Debug.Log("음식 주문 스크립트!");
                } 
                else if (nearestObj.CompareTag("qrCode"))
                {
                    Debug.Log("qr코드");
                    GameObject.Find("Canvas").GetComponent<UIManager>().QRCheck();
                }

                else if (nearestObj.CompareTag("subwaySeat"))
                {
                    Debug.Log("지하철 시트 스크립트!");
                    playerPosition = player.transform.position;
                    playerRotation = player.transform.rotation;
                    GameManager.isSit = true;
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    Debug.Log(nearestObj.transform.rotation);
                    Debug.Log(nearestObj.transform.rotation.x + "rotate x");
                    Debug.Log(nearestObj.transform.rotation.y + "rotate y");
                    Debug.Log(nearestObj.transform.rotation.z + "rotate z");
                    player.transform.rotation = Quaternion.Euler(0, nearestObj.transform.rotation.eulerAngles.y, 0);

                    player.transform.localPosition = new Vector3(nearestObj.transform.position.x + 0.0065f,
                                                            nearestObj.transform.position.y - 0.001f,
                                                            nearestObj.transform.position.z);
                    animator.SetFloat("v", 0);
                    animator.SetFloat("h", 0);
                    animator.SetInteger("Sit", 2);
                    //Debug.Log("성공!");
                    foreach (GameObject inst in interactionList)
                    {
                        inst.GetComponent<Outline>().OutlineColor = new Color(1, 1, 1, 0);
                    }
                    interactionList.Clear();
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("충돌 " + other.transform.gameObject.ToString());
        if (other.transform.parent.CompareTag("cafeSeat")
         || other.transform.parent.CompareTag("cafeOrder")
         || other.transform.parent.CompareTag("qrCode")
         || other.transform.parent.CompareTag("subwaySeat"))
            interactionList.Add(other.transform.parent.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("cafeSeat")
         || other.transform.parent.CompareTag("cafeOrder")
         || other.transform.parent.CompareTag("qrCode")
         || other.transform.parent.CompareTag("subwaySeat"))
        {
            other.transform.parent.GetComponent<Outline>().OutlineColor = new Color(1, 1, 1, 0);
            interactionList.Remove(other.transform.parent.gameObject);
        }

    }
}
