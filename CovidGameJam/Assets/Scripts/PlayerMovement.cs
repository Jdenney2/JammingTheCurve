using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
 //player movement variables
    public CharacterController controller;
    public Transform cam;
    private Transform playerPos;
    public float speed = 6f;
    public float gravity = -9.8f;
    public float jumpHeight = 8f;
    public float turnSmoothTime = 0f;
    float turnSmoothVeloctiy;
    Vector3 velocity;

    //player animation variables
    //public Animator animator;
    //private bool isIdle, isRunning, isJumping, isBacking, isAttacking, canDoubleJump, canAttack, isDoubleJumping, pause = false;
    private bool pause = false, isAttacking = false;
    //attack cooldown so the player cant spam attack animation
    private float attackCooldown;
    
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if(!pause)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            //velocity with gravity allows the player to fall
            //this resets velocity so it is not always adding up in the background
            if(controller.isGrounded)
            {
                //controller.transform.position = Vector3.zero;               

                velocity.y = -2f;
            }
                
            if(direction.magnitude >= 0.1f && isAttacking == false)
            {
                //target angle takes the x and z axis to get a y angle of movement
                //this is how we move diagonally
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVeloctiy, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime);
            }

            //check to see if the jump key is pressed (space bar in this case)
            if(controller.isGrounded)
            {
                if(Input.GetKey(KeyCode.Space))
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
            
            //this is our gravity
            //note needs to be after jump 
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }
       
        else if(pause)
        {

        }

    }

    private IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(.6f);
        //canAttack = true;
    }

    public void Pause()
    {
        pause = true;
    }

    public void Unpause()
    {
        pause = false;
    }
}
