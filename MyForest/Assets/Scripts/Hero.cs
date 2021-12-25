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
    
    public AudioClip chestAudio;
    public AudioClip[] collectAudios;


    public Text MedkitCountText;
    public Text AmmoCountText;
    public Text KeyCountText;
    public Text InformationText;

    public float infoTextTimer;
    private float counter;

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

        if (!InformationText.text.Equals(""))
        {
            counter += Time.deltaTime;
        }

        if (counter >= infoTextTimer)
        {
            InformationText.text = "";
            counter = 0;
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
        InformationText.text = (4-m_KeyCount) + " Key(s) Left ..";
    }

    public void UpdateUI()
    {
        MedkitCountText.text = m_MedkitCount.ToString();
        AmmoCountText.text = gun.m_bulletCount.ToString();
        KeyCountText.text = m_KeyCount.ToString();
    }

    public void PlayCollectAudio(int audioIndex)
    {
        AudioSource audioSource;

        if (audioIndex == 1)
        {
            audioSource = gun.GetComponent<AudioSource>();
        }
        else
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        
        audioSource.clip = collectAudios[audioIndex];
        audioSource.Play();
    }
}
