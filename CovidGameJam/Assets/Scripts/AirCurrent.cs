using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCurrent : MonoBehaviour
{
    public float force, gravityValue, t = 0.0f, min, max, seconds;
    public bool up, outward;
    private bool moveUp, moveOut;
    public CharacterController controller;
    private Vector3 playerVelocity;

    void Start()
    {
        moveUp = false;
        moveOut = false;
    }

    void Update()
    {
        
        if(moveUp == true)
        {
            StartCoroutine(Delay());
            playerVelocity.y += Mathf.Lerp(min, max, t);
            t += 0.5f * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            if(t >= 0.3f)
            {
                float temp;
                temp = min;
                min = max;
                max = temp;
                t = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player" && up == true)
        {
            playerVelocity.y = 0.0f;
            moveUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag =="Player")
        {
            float temp;
            temp = min;
            min = max;
            max = temp;
            t = 0.0f;
        }        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(seconds);
        moveUp = false;
        // playerVelocity.y = 0.0f;
        // float temp;
        // temp = max;
        // max = min;
        // min = temp;
        // t = 0.0f;
    }
}
