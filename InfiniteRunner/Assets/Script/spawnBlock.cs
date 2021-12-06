using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnBlock : MonoBehaviour
{
    private GameObject Block;
    public GameObject Collectable;
    public GameObject Obstacle;
    private float offset = 10.0f;
    private float coloffset = 5.0f;
    // Use this for initialization
    void Start()
    {
        //find the block object
        Block = GameObject.Find("Block");
        Collectable = GameObject.Find("Collectable");
        Obstacle = GameObject.Find("Obstacle");
    }


    void OnTriggerEnter(Collider other)
    {
        //add a new block relative to the z position of the current block
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z + offset));
        Instantiate(Block, newPos, transform.rotation);

        Vector3 newPos2 = new Vector3(Random.Range(-3.5f, 4.2f),Random.Range(0.7f, 5.4f), (float)(transform.position.z + coloffset));
        Instantiate(Collectable, newPos2, transform.rotation);

        Vector3 newPos3 = new Vector3(Random.Range(-3.5f, 4.2f), Random.Range(0.7f, 5.4f), (float)(transform.position.z + offset));
        Instantiate(Obstacle, newPos3, transform.rotation);
    }
}
