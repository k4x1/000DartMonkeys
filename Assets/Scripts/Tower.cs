using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{



    public int m_Price = 10;
    public int m_UpgradeCost;
    public int m_Level;
    public GameObject m_CityRef;
    protected City m_CityClassRef = null; 

     void Start()
     {
        m_CityRef = GameObject.FindGameObjectsWithTag("City")[0];
        m_CityClassRef = m_CityRef.GetComponent<City>();
     }
    public void Placed(){
        //runs when object is placed
    }
    public void Upgrade(){
        //runs when object upgraded
    }
}



