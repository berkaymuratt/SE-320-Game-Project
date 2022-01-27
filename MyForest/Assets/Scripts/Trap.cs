using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Hero m_Hero;
    private AudioSource AudioSource;
    
    void Start()
    {
        m_Hero = GameObject.Find("Hero").GetComponent<Hero>();
        AudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Hero"))
        {
            AudioSource.Play();
            m_Hero.GetDamage(20);
        }
    }
}
