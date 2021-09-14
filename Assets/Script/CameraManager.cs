using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //public GameObject target;
    public Vector3 offset;
    public float dis;
    private Vector3 axisVec;
    private Transform mainCamera;
    public float zoomSpeed;

    public Vector3 defaultVect;


    public Transform centralAxis;
    public float rotateSpeed;
    float mouseX;
    float mouseY;

    public Transform playerAxis;
    public Transform player;
    public Transform playerChange;


    // Start is called before the first frame update
    void Start()
    {
        //offset = mainCamera.transform.position - target.transform.position;

        mainCamera = Camera.main.transform;

        zoomSpeed = 0.05f;
        rotateSpeed = 10;

        defaultVect = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.maskOn == false)
        {

        }
        else
        {
            zoom();
            move();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                if (Input.GetMouseButton(1))
                    return;
                //dis = -0.054f;
                centralAxis.transform.rotation = Quaternion.Euler(0, 0, 0);
                mouseX = 0;
                mouseY = 0;
            }
        }
       
    }

    void zoom()
    {
        dis += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        if (dis < -0.1f)
            dis = -0.1f;
        if (dis >= -0.054f)
            dis = -0.054f;
        mainCamera.localPosition = new Vector3(0, 0, dis);
    }

    void move()
    {
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Input.GetAxis("Mouse Y") * -1;

            if (mouseY > 5)
                mouseY = 5;
            if (mouseY < 0)
                mouseY = 0;


            centralAxis.rotation = Quaternion.Euler(
                new Vector3(centralAxis.rotation.x + mouseY,
                centralAxis.rotation.y + mouseX, 0) * rotateSpeed);

            playerAxis.rotation = Quaternion.Euler(
                new Vector3(0, playerAxis.rotation.y + mouseX, 0) * rotateSpeed);

        }
    }


    private void LateUpdate()
    {

        if (GameManager.maskOn == false)
        {
            centralAxis.position
            = new Vector3(playerChange.transform.position.x, 0.03f, playerChange.transform.position.z);
        }
        else
        {
            centralAxis.position
                = new Vector3(player.transform.position.x, 0.03f, player.transform.position.z);
        }
    }

}
