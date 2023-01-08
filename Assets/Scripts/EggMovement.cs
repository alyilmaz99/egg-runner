using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed, jumpForce;
    [SerializeField] private Vector3 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, 1);

        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
