using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timer = 60.0f;
    public DamageReport damageReport;
    public PlayerController player;
    private Text text;
    private bool timeUp = false;
    private GameObject[] npcs;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 0 && timeUp == false)
        {
            timer = 0.0f;
            text.text = (timer).ToString("0");
            timeUp = true;
            damageReport.ShowResults();
            player.canMove = false;
            Cursor.lockState = CursorLockMode.None;

            for(int i = 0; i < npcs.Length; i++){
                npcs[i].GetComponent<NPCMove>().stationary = true;
            }
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            text.text = (timer).ToString("0");
            player.canMove = true;
        }
    }

}
