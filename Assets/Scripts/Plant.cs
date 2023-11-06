using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPlantDecorator
{
    int GetiDamage { get; }
    int GetiHealth { get; }
    float GetfBattleSpeed { get; }
    // void Decorate(Plant plant);
}
public class BasePlant : IPlantDecorator
{
    int Health = 10;
    int Damage = 1;
    float BattleSpeed = 1;
    public int GetiDamage
    {
        get
        { 
            return Damage;
        }
    }
     public int GetiHealth
     {
        get
        {
            return Health;
        }
     }
     public float GetfBattleSpeed
     {
        get{ 
        return BattleSpeed;
        }
     }

}
public abstract class PlantUpgrade : IPlantDecorator
{
    public IPlantDecorator m_PlantDecorator;
    public void ApplyUpgrade(IPlantDecorator _newPlantDecorator)
    {
        m_PlantDecorator = _newPlantDecorator;
    }
    public virtual int GetiDamage
    {
        get
        {
            return m_PlantDecorator.GetiDamage;
        }
    }
    public virtual int GetiHealth
    {
        get
        {
            return GetiHealth;
        }
    }
    public virtual float GetfBattleSpeed
    {
        get{
            return GetfBattleSpeed;
        }
    }
}
public class Plant : MonoBehaviour 
{

    [SerializeField]
    public float m_fBattleTimerSeconds_max = 1.0f;
    float m_fBattleTimerSeconds_current = 0.0f;
    public int m_iTroopHealth;
    public int m_iTroopDamage;
    public int m_iTroopPos;
    public int m_iTroopCount;
    [SerializeField]

    
   IPlantDecorator m_PlantDecorator = new BasePlant();

    void Start()
    {
        m_fBattleTimerSeconds_current = m_fBattleTimerSeconds_max;
    }
    private void Update()
    {
        if (m_fBattleTimerSeconds_current <= 0)
        {
            BattleEnemy();
            m_fBattleTimerSeconds_current = m_fBattleTimerSeconds_max;
        }
        else
        {
            m_fBattleTimerSeconds_current -= Time.deltaTime;
        }
    }
    public void BattleEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 pos = transform.position;
        Vector3 range = new Vector3(30, 30);
        bool EnemyFound = false;
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyPos = enemy.transform.position;
            if (enemyPos.x>(pos+range).x && (pos + range).x<enemyPos.x)
            {
                if (enemyPos.y > (pos + range).y && (pos + range).y < enemyPos.y)
                {
                    enemy.GetComponent<Balloon>().m_Health -= m_iTroopDamage;
                    m_iTroopHealth -= enemy.GetComponent<Balloon>().m_Damage;
                    EnemyFound = true;
                }
            }
        }
    }
}
