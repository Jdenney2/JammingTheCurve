using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCurrent : MonoBehaviour
{
    public float min, max, seconds;
    private float t = 0.5f;
    public bool up, outX, outZ, D; //D = direction if true then forward if false then backward
    private bool moveUp, outwardZ, outwardX; //x and z are their own axis F = forward B = backward
    public CharacterController controller;
    private Vector3 playerVelocity;
    public PlayerController script;

    void Start()
    {
        moveUp = false;
        outwardZ = false;
        outwardX = false;
    
    }

    void Update()
    {

        if(moveUp)
        {
            script.canMove = false;
            StartCoroutine(Delay());
            playerVelocity.y += Mathf.Lerp(min, max, t);
            t += 0.5f /* Time.deltaTime*/;

            controller.Move(playerVelocity * Time.deltaTime );
        }

        if(outwardZ)
            LaunchZ();
        

        if(outwardX)
            LaunchX();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player" && up == true)
        {
            playerVelocity.y = 0.0f;
            playerVelocity.x = 0.0f;
            playerVelocity.z = 0.0f;
            moveUp = true;
        }

        if(other.tag =="Player" && outZ == true)
        {
            playerVelocity.y = 0.0f;
            playerVelocity.x = 0.0f;
            playerVelocity.z = 0.0f;
            outwardZ = true;
        }

        if(other.tag =="Player" && outX == true)
        {
            playerVelocity.y = 0.0f;
            playerVelocity.x = 0.0f;
            playerVelocity.z = 0.0f;
            outwardX = true;
        }
    }

    private void LaunchZ()
    {
       StartCoroutine(Delay());

        //launch forward along z axis
        if(D)
            playerVelocity.z -= Mathf.Lerp(min, max, t);
        

        //launch backward along the z axis
        if(!D)
            playerVelocity.z += Mathf.Lerp(min, max, t);           
        

        t += 0.5f * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void LaunchX()
    {
        StartCoroutine(Delay());

        //launch left along x axis
        if(D)
            playerVelocity.x += Mathf.Lerp(min, max, t);
        

        //launch right along the x axis
        if(!D)
            playerVelocity.x -= Mathf.Lerp(min, max, t);           
        

        t += 0.5f * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(seconds);
        script.canMove = true;
        moveUp = false;
        outwardZ = false;
        outwardX = false;

        //reset everything so player can ride current again
         t = 0.5f;

    }
}
