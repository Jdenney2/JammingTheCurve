using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionSwitch : MonoBehaviour
{
    public bool infected = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Employee")
        {
            infected = false;
        }

        if(other.tag == "Player")
        {
            infected = true;
        }

        if(other.tag == "NPC" && other.GetComponent<NPCStarts>().isInfected == true)
        {
            infected = true;
        }
    }
}
