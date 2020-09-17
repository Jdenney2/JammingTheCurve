using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physics variables, for now they are random, and will need a great deal of tuning
    public float speed = 1.0f;
    public float jumpForce = 40.0f;

    //Logic variables

    //References

    //Components
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis ("Horizontal");
        float moveV = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        myRigidbody.AddForce(movement * speed);

        if (Input.GetButtonDown("Jump")) {
            myRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
