using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector3 pos;

    public float v = 0.0f;
    public float h = 0.0f;
    public float moveSpeed = 0.05f;
    public float rotationSpeed = 10f;
    public Rigidbody player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        player.mass = 4;
        player.drag = 10;

        moveSpeed = 0.05f;
        rotationSpeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPause || GameManager.isSit)
            return;
        //move();
        //ani();
        movetest();
    }

    void movetest()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            player.rotation = Quaternion.Slerp(player.rotation, Quaternion.Euler(0, angle, 0), rotationSpeed * Time.fixedDeltaTime);      
        }
        //player.AddForce(Vector3.forward, ForceMode.Force);


        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Translate(direction * Time.deltaTime * moveSpeed, Space.World);
        //move();
        if (h > 0.1f || h < -0.1f || v > 0.1f || v < -0.1f)
            animator.SetFloat("v", 1);
        else
            animator.SetFloat("v", 0);
        //player.position = direction * moveSpeed * Time.fixedDeltaTime;
    }

    void move()
    {
        pos = gameObject.transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(Vector3.forward, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(Vector3.left, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(Vector3.back, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(Vector3.right, ForceMode.Force);
        }


    }

    void ani()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        animator.SetFloat("v", v);
        animator.SetFloat("h", h);
    }
}
