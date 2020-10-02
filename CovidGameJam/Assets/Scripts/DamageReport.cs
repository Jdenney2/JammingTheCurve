using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageReport : MonoBehaviour
{   
    public Text title, peopleInfected, objects_with_covid, totalPoints, restOrCont;
    private int PI = 0, TP = 0, TO = 0, OWC = 0; //peopleInfected, total ppl, total objects, objects with covid

    // Start is called before the first frame update
    void Start()
    {
        title.text = "";
        peopleInfected.text = "";
        objects_with_covid.text = "";
        totalPoints.text = "";
        restOrCont.text = "";
    }

    public void ShowResults()
    {
        CalculateObjects();
        CalculatePeople();

        title.text = "Report";
        peopleInfected.text = "People Infected :\n" + PI + "/" + TP;
        objects_with_covid.text = "Objects with Covid:\n" + OWC + "/" + TO;
        int total = (PI * 10) + (OWC * 5);
        restOrCont.text = "Press Enter to Restart\n\nPress Escape to Quit";

        totalPoints.text = "Total points for infection: " + PI + " x 10 " + " + " + OWC + " x 5\n\n" + total + " points";
    }

    private void CalculatePeople()
    {
        GameObject[] objs;

        objs = GameObject.FindGameObjectsWithTag("NPC");
        TP = objs.Length;

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

        objs = GameObject.FindGameObjectsWithTag("NonNPC");
        TO = objs.Length;

        foreach(GameObject go in objs)
        {
            if(go.GetComponent<InfectionSwitch>().infected== true)
            {
                OWC++;
            }
        }
    }
}
