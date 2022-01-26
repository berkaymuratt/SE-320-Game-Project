using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Hero m_Hero;
    
    void Start()
    {
        m_Hero = GameObject.Find("Hero").GetComponent<Hero>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            m_Hero.GetDamage(20);
        }
    }
}
