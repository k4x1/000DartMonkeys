using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Tower
{
    [SerializeField]
    public float m_fShootTimerSeconds_max = 4.0f;
    float m_fShootTimerSeconds_current = 0.0f;
    public int m_Damage = 1;
    public int m_AttackSpeed = 1;
    [SerializeField]
    public GameObject m_PrefabProjectile;
    GameObject m_InstanceTarget = null;
    private void Start()
    {
        m_fShootTimerSeconds_current = m_fShootTimerSeconds_max;
    }
    private void Update()
    {
        if(m_fShootTimerSeconds_current <= 0)
        {
            SearchforTarget();
            if (m_InstanceTarget != null) { 
             Attack();
            }
            m_fShootTimerSeconds_current = m_fShootTimerSeconds_max;
        }
        else
        {
            m_fShootTimerSeconds_current -= Time.deltaTime; 
        }
    }

    protected void Attack()
    {
        Instantiate(m_PrefabProjectile,gameObject.transform.position,Quaternion.identity);
    }
    protected void SearchforTarget()
    {
        m_InstanceTarget = FindClosestTarget();
        if (m_InstanceTarget != null)
        {
            Debug.Log("targetfound");
        }
        else
        {
            Debug.Log("failed to found");
        }
    } 
    public GameObject FindClosestTarget()
    {
        //return no if failed 
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        Vector3 startPos = transform.position;
        float distance = 600.0f;
        foreach (GameObject enemy in enemies)
        {
            Vector3 vecdist = enemy.transform.position - startPos;
            float currentDistance  = vecdist.magnitude;
            if (currentDistance < distance)
            {
                closestEnemy = enemy;
                distance = currentDistance;
            }
        }
        return closestEnemy;
    }

}
