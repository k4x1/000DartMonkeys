using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 m_velocity = new Vector3(1.0f, 0.0f, 0.0f);
    public float m_fDamage = 10.0f;
    public float m_fRange= 600.0f;
    public void InitProjectile(Vector3 _ProjVelocity, float _Damage, float _Range)
    {
        m_velocity = _ProjVelocity;
        m_fDamage = _Damage;
        m_fRange = _Range;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_fRange >= 0.0f) {
            gameObject.transform.Translate(m_velocity*Time.deltaTime);
            m_fRange-=m_velocity.magnitude*Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
 