using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Text shieldStr;
    Renderer rend; 
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 90.0f * 1.0f * Time.deltaTime, 0.0f, Space.Self);

        /*
            here will be an if / else changing color of infected or not
            this will also bridge and change UI text for shield str
        */
    }
}
