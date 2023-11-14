using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Barrack : Tower
{
    public enum BarrackType { type_cactus, type_potato, type_cucumber };
    
    public float m_fProductionRate = 3.0f;
    public float m_fPlantTimer = 0.0f;
    public BarrackType Type = BarrackType.type_cactus;
    private GameObject currentPlant;
    public GameObject Cactus;
    public GameObject Potato;
    public GameObject Cucumber;
    float m_fDistance = 0.0f;

    public void CreatePlantFactory(){
        //UnityEngine.Debug.Log("asdfsafd");
        switch (Type) {
            case(BarrackType.type_cactus):
                currentPlant = Cactus;
                m_fDistance = 5.0f;
                break;    
            case(BarrackType.type_potato):
                currentPlant = Potato;
                m_fDistance = 10.0f;
                break;    
            case(BarrackType.type_cucumber):
                currentPlant = Cucumber;
                m_fDistance = 15.0f;
                break;


        }
    }


    void Start()
    {
        m_CityRef = GameObject.FindGameObjectsWithTag("City")[0];
        m_CityClassRef = m_CityRef.GetComponent<City>();
        m_fPlantTimer = m_fProductionRate;
        CreatePlantFactory();
    }
    private void Update()
    {
        if (m_fPlantTimer <= 0)
        {
            
            m_fPlantTimer = m_fProductionRate;
            CreatePlant();

        }
        else
        {
            m_fPlantTimer -= Time.deltaTime;
        }
    }
    void CreatePlant()
    {
        Instantiate(currentPlant,new Vector3(transform.position.x+ m_fDistance, 0), Quaternion.identity);
    }
  
}
