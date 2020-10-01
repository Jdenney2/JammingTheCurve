using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUI : MonoBehaviour
{
    public Text attack;
    private GameObject closest;

    void Update()
    {
        closest = FindClosestEnemy();

        float distance = Vector3.Distance(transform.position, closest.transform.position);

        if(distance < 4.5f)
            attack.text = "Attack!\n(LMB)";
        
        else
            attack.text = "";     
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("NPC");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach(GameObject go in enemies)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }
}
