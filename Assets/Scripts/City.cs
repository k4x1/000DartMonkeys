using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class City : MonoBehaviour
{
    static int MaxHealth = 100;
    public int Health = MaxHealth;
    public int Doubloons = 0;
    public int Wood = 1;
    public int CityLevel = 1;
    public int Round = 1;
    public int TowerNumber = 0; //amount of towers
    public GameObject Turret;
    public GameObject Factory;
    public GameObject Barrack;
    public static List<GameObject> TowerReferences = new List<GameObject>();

    private void Update()
    {
      
    }

    void UpgradeCity(){
        CityLevel++;
    }
    void StartRound(){
        Round++;
    }
    void CreateTower(GameObject _tower, Vector3 _pos){
        TowerNumber++;
        Instantiate(_tower,_pos,Quaternion.identity);
        //add tower to tower references
    }
    void TakeDamage(int _damage){
        Health -= _damage;
    }
    void Die(){
        //restart game
    }
}
