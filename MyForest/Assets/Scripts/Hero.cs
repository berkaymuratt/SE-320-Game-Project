using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public Gun gun;
    public int health;
    public int medkitValue;
    public int requiredKeysCount;

    public int medkitCount;
    public int keyCount;
    
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
        medkitCount = 0;
        keyCount = 0;
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            UseMedKit();
        }
        
        CheckInfoText();
    }

    private void CheckInfoText()
    {
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

    private void UseMedKit()
    {
        if (health < 100)
        {
            health += medkitValue;
            
            if (health > 100)
            {
                health = 100;
            }
        }
        else
        {
            InformationText.text = "Your health is full !";
        }
    }

    public void GetMedkit()
    {
        medkitCount++;
    }

    public void GetAmmo()
    {
        gun.m_bulletCount += 5;
    }

    public void GetKey()
    {
        keyCount++;
        InformationText.text = (requiredKeysCount-keyCount) + " Key(s) Left ..";
    }

    public void UpdateUI()
    {
        MedkitCountText.text = medkitCount.ToString();
        AmmoCountText.text = gun.m_bulletCount.ToString();
        KeyCountText.text = keyCount.ToString();
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
