using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Tower
{
    [SerializeField]
    public float m_fShootTimerSeconds_max = 4.0f;
    public float m_fShootTimerSeconds_current = 0.0f;
    public float m_ProjSpeed = 5;
    public int m_Damage = 1;
    public int m_AttackSpeed = 1;
    public Vector3 m_ProjVelocity = new Vector3(1.0f, 0.0f, 0.0f);
    public float m_Range = 600.0f;
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
            m_fShootTimerSeconds_current = m_fShootTimerSeconds_max;
            SearchforTarget();
            if (m_InstanceTarget != null) { 
             Attack();
            }
           
        }
        else
        {
            m_fShootTimerSeconds_current -= Time.deltaTime; 
        }
    }

    protected void Attack()
    {
       GameObject shotProj = Instantiate(m_PrefabProjectile,gameObject.transform.position,Quaternion.identity);
        shotProj.GetComponent<Projectile>().InitProjectile(m_ProjVelocity, m_Damage, m_Range);
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
        float distance = m_Range;

      

        foreach (GameObject enemy in enemies)
        {
            Vector3 vecdist = enemy.transform.position - startPos;

            float currentDistance  = vecdist.magnitude;
            Vector3 normalizedVector = vecdist.normalized;

            if (currentDistance < distance)
            {
                /*                float normalX = (vecdist.x - startPos.x) / enemy.transform.position.x - startPos.x;
                                float normalY = (vecdist.y - startPos.y) / enemy.transform.position.y - startPos.y;
                                m_ProjVelocity = new Vector3(normalX, normalY, 0);*/
                m_ProjVelocity = normalizedVector * 0.5f;
                m_ProjVelocity *= m_ProjSpeed;
                closestEnemy = enemy;
                distance = currentDistance;
            }
        }
        return closestEnemy;
    }

}
