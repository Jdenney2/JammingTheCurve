using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Physics variables, for now they are random, and will need a great deal of tuning
    public float speed = 2.0f;
    public float atkSpeed = 5f;
    public float gravity = 9.0f;
    public float jumpSpeed = 10.0f;
    public float rotateSpeed = 3.0f;
    private float cameraAngle;
    public float maxCameraRotation = 50.0f;
    private float moveDirY;
    Quaternion oldRotation;
    Vector3 moveDirection = Vector3.zero;

    //Logic variables
    private bool isGrounded, gravityOn;
    private bool isAttacking;

    //References
    public GameObject pivotPoint;
    private GameObject target = null;

    //Components
    private CharacterController charController;

    //Timing Vars
    private float curReboundTimer;
    public float reboundTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cameraAngle = 0;
        moveDirY = 0;
        isAttacking = false;
        curReboundTimer = 0;
    }

    void Update()
    {        
        if(charController.isGrounded)
            gravityOn = true;
        else
            gravityOn = false;

        if(gravityOn)
            moveDirY = -9f;

        //Handle Camera Vertical Rotation
        cameraAngle += -Input.GetAxis("Mouse Y") * rotateSpeed;
        cameraAngle = Mathf.Clamp(cameraAngle, -maxCameraRotation, maxCameraRotation);
        pivotPoint.transform.localRotation = Quaternion.AngleAxis(cameraAngle, Vector3.right);

        if (!isAttacking && curReboundTimer <= 0) {
            //Handle Player Horizontal Rotation
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

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

            //If the player hits the attack button, has a target, and can attack, then handle that here
            if(Input.GetButtonDown("Fire1") && target != null) {
                oldRotation = transform.rotation;
                isAttacking = true;
            }
        }

        if (isAttacking) {
            transform.LookAt(target.GetComponent<NPCStarts>().head);

            moveDirection = new Vector3(0, 0, 1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= atkSpeed;

            charController.Move(moveDirection * Time.deltaTime);

            //If distance is below a certain threshold, damage the targets defense then begin to bounce backwards
            //Note: May have to tinker with the threshold value
            if (Vector3.Distance(transform.position, target.GetComponent<NPCStarts>().head.position) <= 0.7) {
                target.GetComponent<NPCStarts>().defense -= 1.5f;
                if(target.GetComponent<NPCStarts>().defense <= 0f) {
                    target.GetComponent<NPCStarts>().isInfected = true;
                }

                isAttacking = false;
                curReboundTimer = reboundTime;
            }
        }

        if (curReboundTimer > 0) {
            moveDirection = new Vector3(0, 0, -1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= atkSpeed;

            charController.Move(moveDirection * Time.deltaTime);
            curReboundTimer -= Time.deltaTime;

            if (curReboundTimer <= 0) {
                //When done rebounding, reset the rotation
                transform.rotation = oldRotation;
            }
        }

    }

    public void TurnGravity()
    {
        gravityOn = !gravityOn;
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "NPC" && !other.gameObject.GetComponent<NPCStarts>().isInfected) {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        target = null;
    }

}
