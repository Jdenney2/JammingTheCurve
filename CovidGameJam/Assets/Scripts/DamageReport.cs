using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReport : MonoBehaviour
{   
    public Text title, peopleInfected, objects_with_covid;
    private int PI = 0, OWC = 0; //peopleInfected and objects with covid

    // Start is called before the first frame update
    void Start()
    {
        title.text = "";
        peopleInfected.text = "";
        objects_with_covid.text = "";
    }

    public void ShowResults()
    {
        CalculateObjects();
        CalculatePeople();

        title.text = "Report";
        peopleInfected.text = "People Infected :\n" + PI;
        objects_with_covid.text = "Objects with Covid:\n" + OWC;
    }

    private void CalculatePeople()
    {
        GameObject[] objs;

        objs = GameObject.FindGameObjectsWithTag("NPC");

        foreach(GameObject go in objs)
        {
            if(go.GetComponent<NPCStarts>().isInfected == true)
            {
                PI++;
            }
        }
    }

    private void CalculateObjects()
    {
        GameObject[] objs;

        objs = GameObject.FindGameObjectsWithTag("Object");

        foreach(GameObject go in objs)
        {
            if(go.GetComponent<InfectionSwitch>().infected == true)
            {
                OWC++;
            }
        }
    }
}
