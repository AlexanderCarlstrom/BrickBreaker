using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    //movement speed in units per second
    public float xSpeed = 1f;
    public float ySpeed = 1f;

    private Vector3 previous;
    private Vector3 velocity;
    private bool first = true;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
        transform.position = transform.position + new Vector3(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, 0);

        if (first)
        {
            previous = transform.position;
            first = false;
        }

        velocity = (transform.position - previous) / Time.deltaTime;
        previous = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Wall":
                var contact = col.contacts[0].normal;
                var v = Vector3.Reflect(velocity, contact);
                xSpeed = v.x;
                ySpeed = v.y;
                break;
            case "Bottom":
                xSpeed = 0;
                ySpeed = 0;
                break;
            default:
                Physics2D.IgnoreCollision(col.collider, GetComponent<CircleCollider2D>());
                break;
        }
    }
}
