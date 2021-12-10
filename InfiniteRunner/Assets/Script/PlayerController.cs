using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // The Moving Speed
    public float speed;

    // Expolsion For Ship when wall is hit
    public GameObject explode;

    // Bullet
    public GameObject projectile;
    private float timeWhenAllowedNextShoot = 0f;
    private float timeBetweenShooting = 1f;

    //Thrust move ball up and down
    public float thrust;

    // This holds the rigiboyd component of the object
    private Rigidbody rb;

    //keeps track of score
    public int score = 0;
    public int totalscore = 0;
    public int timescore;
    private bool alive;
    private float startTime;

    //Shoot Force
    public int shootForce = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        alive = true;
        startTime = Time.time;
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
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            alive = false;
        }

        if (other.gameObject.tag == "obstacle")
        {
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
            alive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetButtonDown("Jump"))
            {

                var bullet = Instantiate(projectile, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }

        if (alive)
        timescore = (int)(Time.time - startTime);
    }

    //when trigger collision happens
    void OnTriggerEnter(Collider other)
    {
        //if the other object entering our trigger zone
        //has a tag called "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //Add point for User
            totalscore += 10;
            //deactivate the other object
            other.gameObject.SetActive(false);
        }
    }

    public int returnScore() {

        score = totalscore + timescore;
        return score;
    }
}