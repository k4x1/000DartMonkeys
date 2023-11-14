using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int m_Health = 100;
    public int m_Damage;
    public int m_Speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(m_Speed*Time.deltaTime,0);
        if(m_Health <= 0)
        {
            transform.position = new Vector3(1000, 0);
            m_Health = 100;
        }
    }
}
