using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int m_Health = 100;
    public int m_Damage;
    public int m_Speed = 10;
    // Start is called before the first frame update
    public GameObject m_CityRef;
    protected City m_CityClassRef = null;

    void Start()
    {
        m_CityRef = GameObject.FindGameObjectsWithTag("City")[0];
        m_CityClassRef = m_CityRef.GetComponent<City>();
        transform.position = new Vector3(transform.position.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(m_Speed*Time.deltaTime,0);
        if(m_Health <= 0)
        {
            m_CityClassRef.Wood++;
            m_CityClassRef.Doubloons++;
            transform.position = new Vector3(1030, 0);
            Instantiate(gameObject, transform);
            transform.position = new Vector3(1000, 0);
            m_Health = 100;
        }
    }
}
