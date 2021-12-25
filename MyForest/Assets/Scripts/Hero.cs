using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Gun gun;
    public int health;

    private int m_MedkitCount;
    private int m_KeyCount;

    // Update is called once per frame
    void Start()
    {
        m_MedkitCount = 0;
        m_KeyCount = 0;
        health = 100;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
        }
        
        Debug.Log("Medkit: " + m_MedkitCount);
        Debug.Log("Ammo: " + gun.m_bulletCount);
        Debug.Log("Key: " + m_KeyCount);
    }

    public void getDamage(int value)
    {
        health -= value;
    }

    public void getMedkit()
    {
        m_MedkitCount++;
    }

    public void getAmmo()
    {
        gun.m_bulletCount += 5;
    }

    public void getKey()
    {
        m_KeyCount++;
    }
}
