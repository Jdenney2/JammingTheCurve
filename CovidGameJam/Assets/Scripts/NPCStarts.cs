using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStarts : MonoBehaviour
{

    public bool isInfected = false;

    /*
    Important note: The defense stat of an NPC is functionally the same as health in the vast
    majority of games, but it plays an even more signifigant role in the simulation aspect of
    this game. Defense represents a person's "defense" against Covid19, and as a result should
    be calculated by large number of variables. When a player attacks a healthy NPC, it will drop
    their defense, and once this stat reaches 0, an NPC is considered "infected," and can no loger be
    attacked. This stat should also be dropped by other things, such as the breaking of social distancing
    measures, but for the sake of gameplay, should never be reduced to 0 unless the player attacks the target.
    */

    public float defense;

    //Values used to calculate the defense of the NPC
    public bool hasMask;

    /*
    Important note: The following variable is used to calculate how much risk is added when social distancing is broken
    (modeled by reducing the defense stat of the npc.) This number needs to be tuned to match the actual effects that 
    breaking social distancing would cause, but for now, this is purely a placeholder value
    */
    public float socialDistancingDamageRate = 0.05f;
    
    //Refernce used to allow the payer to target NPC's head with as little work as possible
    public Transform head;
        
    // Start is called before the first frame update
    void Start()
    {
        calcuateDefense();          
    }

    public void calcuateDefense() {
        /*
            This function will use a list of values to calculate the defense stat of the NPCs. 
            Initially, it will only use the presence of a mask to determine it, but as development
            progresses, more variables wil be added to the calculation.
        */

        if (hasMask) {
            defense = 6f;
        }
        else {
            defense = 2f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "NPC")
        {
            defense -= socialDistancingDamageRate * Time.deltaTime;
        }
    }

}
