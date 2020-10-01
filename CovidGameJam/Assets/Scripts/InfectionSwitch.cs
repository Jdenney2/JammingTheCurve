using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionSwitch : MonoBehaviour
{
    public bool infected = false;

    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        if(infected)
            m_Material.color = Color.green;
    }

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
