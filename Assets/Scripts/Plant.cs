using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPlantDecorator
{
     void Decorate(Plant plant);
}
public class Plant : MonoBehaviour 
{
    [SerializeField]
    public int m_TroopHealth;
    public int m_TroopDamage;
    public int m_TroopPos;
    public int m_TroopCount;
    [SerializeField]

    
   IPlantDecorator m_PlantDecorator = new BasePlant();

    void Start()
    {
        
    }
    public void BattleEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 pos = transform.position;
        Vector3 range = new Vector3(30, 30);
        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyPos = enemy.transform.position;
            if (enemyPos.x>(pos+range).x && (pos + range).x<enemyPos.x)
            {
                if (enemyPos.y > (pos + range).y && (pos + range).y < enemyPos.y)
                {
                    enemy.GetComponent<Balloon>().m_Health -= m_TroopDamage;
                    m_TroopHealth -= enemy.GetComponent<Balloon>().m_Damage;
                }
            }
        }
    }
}
