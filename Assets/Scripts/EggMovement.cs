using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : MonoBehaviour
{
    [SerializeField] private Joystick joy;

    public int smooth;

    Rigidbody rb;
    [SerializeField] private float speed, jumpForce , jumpJoystickOffSet;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private bool canJump = true;
    public bool canMove = true;
    [SerializeField] private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim= GetComponent<Animator>();
    }

    
    void Update()
    {
        //Movement();
        if (canMove)
        {
            MovementMobile();
        }
        MovementFixer();
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


    void MovementFixer()
    {
        if (transform.position.x > 1.25f)
        {
            //transform.position = new Vector3(1,transform.position.y,transform.position.z);
            transform.position = Vector3.Slerp(transform.position, new Vector3(1f, transform.position.y, transform.position.z), smooth);
        }
        else if ( transform.position.x < -3.2f)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(-2.8f, transform.position.y, transform.position.z),smooth);
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
            canMove = false;
            anim.SetTrigger("crash");
        }

        else if (other.gameObject.tag == "Water")
        {

            Invoke("WaterDrown", .3f);
        }


    }

    void WaterDrown()
    {
        
        rb.isKinematic = true;
        anim.SetBool("drown", true);
        canMove = false;
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
