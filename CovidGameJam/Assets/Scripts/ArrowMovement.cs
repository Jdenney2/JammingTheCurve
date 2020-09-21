using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private float x, y, z, min, max, t;

    // Start is called before the first frame update
    void Start()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;

        min = 0;
        max = 1;
        t = 0.0f;        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(x, y + Mathf.Lerp(min, max, t), z);
        t += 0.5f * Time.deltaTime;

        if(t > 1f)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0.0f;
        } 
    }
}
