using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Hero : MonoBehaviour
{
    public Gun gun;
    
    private int currentHealth;
    private int maxHealth = 100;

    private int currentStamina=0;
    private int maxStamina = 6;
    
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

    private FirstPersonController firstPersonController;


    // Update is called once per frame
    void Start()
    {
        medkitCount = 0;
        keyCount = 0;
        currentHealth = 100;
        
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Running");
        }

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
        currentHealth -= value;
    }

    private void UseMedKit()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 20;
            
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
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
