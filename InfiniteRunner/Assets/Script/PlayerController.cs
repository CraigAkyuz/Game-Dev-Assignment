using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The Moving Speed
    public float speed;
    
    // Expolsion For Ship when wall is hit
    public GameObject explode;

    //Thrust move ball up and down
    public float thrust;

    // This holds the rigiboyd component of the object
    private Rigidbody rb;

    //keeps track of score
    public int score = 0;

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

        Vector3 movex = new Vector3(moveHorizontal, 0.0f, 0.1f);

        rb.AddForce(movex * speed);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.up * thrust);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.down * thrust);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * thrust);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * thrust);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if (other.gameObject.tag == "obstacle")
        {
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //has a tag called "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Add point for User
            score++;
            Debug.Log(score);
            //deactivate the other object
            other.gameObject.SetActive(false);
        }
    }

}
