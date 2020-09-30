using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRay : MonoBehaviour
{
    public int len;
    public Text shieldStr;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward * len);
        Debug.DrawRay(transform.position, forward, Color.red);

        if(Physics.Raycast(transform.position, forward, out hit))
        {
            if(hit.collider.tag == "NPC")
            {
                shieldStr.text = hit.collider.GetComponent<NPCStarts>().defense.ToString();
            }
            else
            {
                shieldStr.text = "";
            }
        }

    }
}
