using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{
    public NPCStarts stats;
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        transform.Rotate(0.0f, 90.0f * 1.0f * Time.deltaTime, 0.0f, Space.Self);

        if(stats.isInfected)
            m_Material.color = Color.green;
        else
            m_Material.color = Color.blue;
    }
}
