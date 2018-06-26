using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    
    public float GroundDistance = 0.2f;
    
    public LayerMask Ground;
    public Rigidbody rb;
    public float fallMultiplier = 2.5f;
    public float lowMultiplier = 2f;
    

    private Vector3 _velocity;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    public float forwardSpeed;
    public float sideSpeed;
    public float jumpVelocity = 0;
    private bool jumpCheck;
    private bool collideLeftWall = false;
    private bool collideRightWall = false;


    void Start()
    {
        
        _groundChecker = transform.GetChild(0);
    }
    private void Update()
    {
        jumpCheck = Input.GetButtonDown("Jump");
    }

    void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (jumpCheck && _isGrounded)
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
            //rb.velocity = Vector3.up * jumpVelocity;
        }
        transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
        //rb.AddForce(Vector3.forward * forwardSpeed);
        if (forwardSpeed <= 40f)
        {

            forwardSpeed += 0.1f * Time.deltaTime;
            sideSpeed += 0.1f * Time.deltaTime;
        }


        if (transform.position.x <=5 && Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * sideSpeed;
            //rb.AddForce(Vector3.right * sideSpeed);
        }
        if (transform.position.x >= -5 && Input.GetKey("a"))
        {
            transform.position -= transform.right * Time.deltaTime * sideSpeed;
            //rb.AddForce(Vector3.left * sideSpeed);
        }

        /*if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 )
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowMultiplier - 1) * Time.deltaTime;
        }*/
        
    }
    
}
