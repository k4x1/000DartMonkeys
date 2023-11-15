using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Tower
{


    public float m_fProductionRate = 3.0f;
    public float m_fMoneyTimer = 0.0f;

    void Start()
    {
        m_CityRef = GameObject.FindGameObjectsWithTag("City")[0];
        m_CityClassRef = m_CityRef.GetComponent<City>();
        m_fMoneyTimer = m_fProductionRate;
    }
    private void Update()
    {
        if (m_fMoneyTimer <= 0)
        {
            m_CityClassRef.Doubloons++;
            m_fMoneyTimer = m_fProductionRate;

        }
        else
        {
            m_fMoneyTimer -= Time.deltaTime;
        }
    }
}
