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
    public bool stationary = false, isIdle;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        dice = Random.Range(min, max);
        count = Mathf.RoundToInt(dice);

        for(int i = 0; i < allSpots.childCount; i++)
        {
            spots.Add(allSpots.GetChild(i));
        }
    }

    //if stationary is clicked then the npc does not move
    void Update()
    {
        if(!stationary)
            Move();
        else
        {
            isIdle = true;
            animator.SetBool("isIdle", isIdle);
        }
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
