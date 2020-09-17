using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physics variables, for now they are random, and will need a great deal of tuning
    public float speed = 2.0f;
    public float gravity = 9.0f;
    public float jumpSpeed = 10.0f;
    public float rotateSpeed = 3.0f;
    private float cameraAngle;
    public float maxCameraRotation = 50.0f;
    private float moveDirY;
    Vector3 moveDirection = Vector3.zero;

    //Logic variables
    public bool isGrounded;

    //References
    public GameObject pivotPoint;

    //Components
    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cameraAngle = 0;
        moveDirY = 0;
    }

    void Update()
    {        
//Handle Player Horizontal Rotation
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        //Handle Camera Vertical Rotation
        cameraAngle += -Input.GetAxis("Mouse Y") * rotateSpeed;
        cameraAngle = Mathf.Clamp(cameraAngle, -maxCameraRotation, maxCameraRotation);
        pivotPoint.transform.localRotation = Quaternion.AngleAxis(cameraAngle, Vector3.right);

        //Handle Character Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        if (charController.isGrounded  && Input.GetButtonDown("Jump")) {
            moveDirY = jumpSpeed;
        }

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirY -= gravity * Time.deltaTime;
        moveDirection.y = moveDirY;

        charController.Move(moveDirection * Time.deltaTime);
    }
}
