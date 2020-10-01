using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timer = 60.0f;
    public DamageReport damageReport;
    private Text text;
    private bool timeUp = false;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
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
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            text.text = (timer).ToString("0");
        }
    }

}
