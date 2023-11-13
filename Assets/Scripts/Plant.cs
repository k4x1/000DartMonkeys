using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public interface IPlantDecorator
{
    int iDamageGet { get; }
    int iHealthGet { get; }
    float fBattleSpeedGet { get; }
}

public class BasePlant : IPlantDecorator
{
    int iHealth = 10;
    int iDamage = 1;
    float fBattleSpeed = 1;
    public int iDamageGet
    {
        get
        {
            return iDamage;
        }
    }
    public int iHealthGet
    {
        get
        {
            return iHealth;
        }
    }
    public float fBattleSpeedGet
    {
        get
        {
            return fBattleSpeed;
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
    public virtual int iDamageGet
    {
        get
        {
            return m_PlantDecorator.iDamageGet;
        }
    }
    public virtual int iHealthGet
    {
        get
        {
            return iHealthGet;
        }
    }
    public virtual float fBattleSpeedGet
    {
        get
        {
            return fBattleSpeedGet;
        }
    }
}

public class DamageUpgrade : PlantUpgrade
{
    int iDamage = 2;
    public override int iDamageGet
    {
        get
        {
            return m_PlantDecorator.iDamageGet + iDamage;
        }
    }
}

public class HealthUpgrade : PlantUpgrade
{
    int iHealth = 2;
    public override int iHealthGet
    {
        get
        {
            return m_PlantDecorator.iHealthGet + iHealth;
        }
    }
}

public class BattleSpeedUpgrade : PlantUpgrade
{
    float fBattleSpeed = 2.0f;
    public override float fBattleSpeedGet
    {
        get
        {
            return m_PlantDecorator.fBattleSpeedGet + fBattleSpeed;
        }
    }
}

public class Plant : MonoBehaviour
{

    [SerializeField]
    public float m_fBattleTimerSeconds_max = 1.0f;
    public float m_fBattleTimerSeconds_current = 0.0f;
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
        GameObject[] aEnemies;
        aEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 vPos = transform.position;
        Vector3 vRange = new Vector3(2, 2);
        bool bEnemyFound = false;
        foreach (GameObject oEnemy in aEnemies)
        {
            Vector3 vEnemyPos = oEnemy.transform.position;


            if (vEnemyPos.x > vPos.x - vRange.x && vEnemyPos.x < vPos.x + vRange.x)
            {
                if (vEnemyPos.y > vPos.y - vRange.y && vEnemyPos.y < vPos.y + vRange.y)
                {
                    oEnemy.GetComponent<Balloon>().m_Health -= m_iTroopDamage;
                    m_iTroopHealth -= oEnemy.GetComponent<Balloon>().m_Damage;
                    bEnemyFound = true;
                    if (m_iTroopHealth <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}