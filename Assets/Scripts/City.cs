using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class City : MonoBehaviour
{
    static int MaxHealth = 100;
    public int Health = MaxHealth;
    public int Doubloons = 100;
    public int Wood = 1;
    public int CityLevel = 1;
    public int Round = 1;
    public int TowerNumber = 0; //amount of towers
    public GameObject Turret;
    public GameObject Factory;
    public GameObject Barrack;
    public int UpgradeCost = 20;
    public static List<GameObject> TowerReferences = new List<GameObject>();
    public float m_fBattleTimerSeconds_max = 1.0f;
    public float m_fBattleTimerSeconds_current = 0.0f;
    public TMP_Text DoubloonsDisplay;
    public TMP_Text WoodDisplay;
    public TMP_Text CityLevelDisplay;
    public TMP_Text HealthDisplay;
    public GameObject grid;
    int turretY = 11;
    int barrackY = 11;
    int factoryY = 11;   
    int turretX = 15;
    int barrackX = 10;
    int factoryX = 5;
    private void Update()
    {
        DoubloonsDisplay.text = string.Concat("Doubloons: ", Doubloons.ToString());
        WoodDisplay.text = string.Concat("Wood: ", Wood.ToString());
        CityLevelDisplay.text = string.Concat("CityLevel: ", CityLevel.ToString());
        HealthDisplay.text = string.Concat("Health: ", Health.ToString());


        TakeDamage();
        if (Health <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.T) && turretY > -10)
        {
            turretY -= 2;
            CreateTower(Turret, new Vector3(transform.position.x + turretX, turretY));

        } 
        if (Input.GetKeyDown(KeyCode.P) && Wood >= UpgradeCost&&   Doubloons >= UpgradeCost)
        {
            UpgradeCity();

        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            turretY = 11;
            turretX += 3;
        }
        if (Input.GetKeyDown(KeyCode.Y) && factoryY > -10)
        {
            factoryY -= 2;
            CreateTower(Factory, new Vector3(transform.position.x + factoryX, factoryY));

        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            factoryY = 11;
            factoryX += 3;
        }
        if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.I) ||Input.GetKeyDown(KeyCode.O) && barrackY > -10)
        {
            barrackY -= 2;

            GameObject Bar;
            if (Input.GetKeyDown(KeyCode.U)){
                Bar = CreateTower(Barrack, new Vector3(transform.position.x + barrackX, barrackY));
                Bar.GetComponent<Barrack>().Type = global::Barrack.BarrackType.type_potato;
            } 
            else if (Input.GetKeyDown(KeyCode.I)){
                 Bar = CreateTower(Barrack, new Vector3(transform.position.x + barrackX, barrackY));
                Bar.GetComponent<Barrack>().Type = global::Barrack.BarrackType.type_cucumber;
            }

            else if(Input.GetKeyDown(KeyCode.O)){
                 Bar = CreateTower(Barrack, new Vector3(transform.position.x + barrackX, barrackY));
                Bar.GetComponent<Barrack>().Type = global::Barrack.BarrackType.type_cactus;
            }
           
           
        }
        else if (Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.O))
        {
            barrackY = 11;
            barrackX += 3;
        }
    }


    void UpgradeCity(){
        if (Doubloons >= UpgradeCost || Wood>= UpgradeCost) { 
            Doubloons -= UpgradeCost; Wood-=UpgradeCost;
            CityLevel++;
            Health += 100;
        }
    }
    void StartRound(){
        Round++;
    }
    GameObject CreateTower(GameObject _tower, Vector3 _pos){
        int tPrice = _tower.GetComponent<Tower>().m_Price;
        if(Doubloons>= tPrice) {
           Doubloons -= tPrice;
         TowerNumber++;
         GameObject tower = Instantiate(_tower,_pos,Quaternion.identity);
         tower.GetComponent<Tower>().Placed();
            return tower;
        }
        return _tower;
        //grid.SetActive(true);
        //add tower to tower references
    }
    void TakeDamage(){
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 pos = transform.position;
        Vector3 range = new Vector3(2, 2);
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyPos = enemy.transform.position;


            if (enemyPos.x > pos.x - range.x && enemyPos.x < pos.x + range.x)
            {
                if (enemyPos.y > pos.y - range.y && enemyPos.y < pos.y + range.y)
                {


                    if (m_fBattleTimerSeconds_current <= 0)
                    {
                        Health -= enemy.GetComponent<Balloon>().m_Damage;
                        enemy.GetComponent<Balloon>().m_Speed = 0 ;
                        m_fBattleTimerSeconds_current = m_fBattleTimerSeconds_max;

                    }
                    else
                    {
                        m_fBattleTimerSeconds_current -= Time.deltaTime;
                    }
                   
                }
            }
        }
    }
    void Die(){
        //restart game
    }
}
