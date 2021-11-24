using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The Moving Speed
    public float speed;

    // This holds the rigiboyd component of the object
    private Rigidbody rb;

    // Jump 
    public Vector3 jump;

    // How much force is in the Jump
    public float jumpForce = 2.8f;

    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.3f);
        jump = new Vector3(0.0f, 2.0f, 0.0f);


        rb.AddForce(movement * speed);
       

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //has a tag called "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //deactivat the other object
            other.gameObject.SetActive(false);
        }
    }

}
