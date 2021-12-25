using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public Gun gun;
    public int health;
    public int healValue;

    private int m_MedkitCount;
    private int m_KeyCount;


    public Text MedkitCountText;
    public Text AmmoCountText;
    public Text KeyCountText;

    // Update is called once per frame
    void Start()
    {
        m_MedkitCount = 0;
        m_KeyCount = 0;
        health = 100;
        
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            gun.Shoot();
            UpdateUI();
        }
    }

    public void GetDamage(int value)
    {
        health -= value;
    }

    public void UseMedKit()
    {
        if (health < 100)
        {
            health += healValue;
            
            if (health > 100)
            {
                health = 100;
            }
        }
        else
        {
            Debug.Log("Your health is full !");
        }
    }

    public void GetMedkit()
    {
        m_MedkitCount++;
    }

    public void GetAmmo()
    {
        gun.m_bulletCount += 5;
    }

    public void GetKey()
    {
        m_KeyCount++;
    }

    public void UpdateUI()
    {
        MedkitCountText.text = m_MedkitCount.ToString();
        AmmoCountText.text = gun.m_bulletCount.ToString();
        KeyCountText.text = m_KeyCount.ToString();
    }
}
