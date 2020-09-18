using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMove : MonoBehaviour
{
    public int count = 0;
    public float speed = 1f;
    public List<Transform> spots;
    
    //***I had to modify this script because I wrote it to inherit from another but the functionality is there. 
    //just need to add what you need to update
    void Start()
    {

    }

    void Update()
    {

    }

    //move method iterates through list of transforms called spots
    //uses count to do so
    //count is a random number
    public void Move()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, spots[count].transform.position, step);

        if(Vector3.Distance(transform.position, spots[count].transform.position) < 0.001f)
        {
            count = GetRandomCount();
        }
    }

    //GetRandomCount() -> this rolls a dice and decides where the enemy will move in its list of spots
    //keep in mind that it only handles 3 spots at the moment. 
    //need to modify if we are to include more random spots
    public int GetRandomCount()
    {
        float dice = Random.Range(0, 3);

        if(dice >= 0 && dice < 1)
            return 0;
        else if(dice >= 1 && dice < 2)
            return 1;
        else if(dice >= 2 && dice < 3)
            return 2;
        else
            return 0;
    }
    
}
