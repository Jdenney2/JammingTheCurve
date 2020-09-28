using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    public int count = 0, min, max;
    private float dice;
    public Transform allSpots;
    private List<Transform> spots = new List<Transform>();
    public NavMeshAgent agent;

    
    //***I had to modify this script because I wrote it to inherit from another but the functionality is there. 
    //just need to add what you need to update
    void Start()
    {
        dice = Random.Range(min, max);
        count = Mathf.RoundToInt(dice);

        for(int i = 0; i < allSpots.childCount; i++)
        {
            /// All your stuff with transform.GetChild(i) here...
            spots.Add(allSpots.GetChild(i));
        }
    }

    void Update()
    {
        Move();
    }

    //move method iterates through list of transforms called spots
    //uses count to do so
    //count is a random number
    public void Move()
    {
        agent.destination = spots[count].transform.position;

        if(Vector3.Distance(agent.transform.position, spots[count].transform.position) < 1f)
        {
            dice = Random.Range(min, max);
            count = Mathf.RoundToInt(dice);
        }
    }  
}
