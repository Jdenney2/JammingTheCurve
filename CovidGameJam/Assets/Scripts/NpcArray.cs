using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcArray : MonoBehaviour
{
    /*
    If you are sitting there, baffled as to why this script exists, just know that I have tried every other
    method I could think of to get this to work(this being a way to measure distance between npcs,) but none of them functioned properly, 
    leaving this as a last resort.

    If your wondering what the purpose of this is, the answer is that it stores all of the other NPCs in a array that is readily accessible to them
    all, so that they can iterate between them all and properly measure distance between each.

    For the record, YES, this is very dumb, but unity physics have forced my hand. I originally intended to use onTriggerStay() to accomplish this;
    it would have been simple and lightweight, but sadly unity requires a rigidbody for that method to work. Since I didn't want to add another physics
    component to the NPCs, which could needlessly introduce more bugs into the game, I chose to this route.

    For future reference: THIS NEEDS TO BE REWORKED. This will likely bog down performance needlessly, so a better solution should be found ASAP.
    */

    public GameObject[] NPCs;
}
