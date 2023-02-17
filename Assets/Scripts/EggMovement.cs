using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : MonoBehaviour
{
    [SerializeField] private Joystick joy;

    Rigidbody rb;
    [SerializeField] private float speed, jumpForce , jumpJoystickOffSet;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private bool canJump=true;
    [SerializeField] private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    
    void Update()
    {
        //Movement();
        MovementMobile();
    }

    void Movement()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, 1);

        rb.MovePosition(rb.position + direction * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
            anim.SetBool("jumping", true);
        }
    }

    void MovementMobile()
    {
        float joyHorizantalMove = joy.Horizontal * speed * Time.deltaTime;
        float verticalMove = joy.Vertical;

        if(verticalMove> jumpJoystickOffSet && canJump)
        {
            Debug.Log("sss");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
            anim.SetBool("jumping", true);
        }


        Vector3 joyMovement = new Vector3(joyHorizantalMove, 0,speed*Time.deltaTime);
        transform.position += joyMovement;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("yandiniz");
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            anim.SetBool("jumping", false);
        }
    }
}
