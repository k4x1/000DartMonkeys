using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    static int MaxHealth = 100;
    public int Health = MaxHealth;
    public int Doubloons = 0;
    public int Wood = 1;
    public int CityLevel = 1;
    public int Round = 1;
    public int TowerNumber = 0;

    void UpgradeCity(){
        CityLevel++;
    }
    void StartRound(){
        Round++;
    }
    void CreateTower(){
        TowerNumber++;
    }
    void TakeDamage(int _damage){
        Health -= _damage;
    }
    void Die(){
        //restart game
    }
}
