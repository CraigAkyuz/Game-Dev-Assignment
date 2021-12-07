using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{

    // Expolsion For Ship when wall is hit
    public GameObject explode;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
        if (other.gameObject.tag == "obstacle")
        {
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "ground")
        {
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
